﻿using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BilgiLigiContestApi.Services;
using BilgiLigiSecurityApi.DataLayer.Repositories;
using BilgiLigiSecurityApi.DTOs;
using BilgiLigiSecurityApi.DTOs.IdentityModels;
using BilgiLigiSecurityApi.DTOs.UserModels;

namespace BilgiLigiSecurityApi.Services.Identity
{
    public class IdentityService :BaseService,IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEncryptionService _encryptionService;
        public IdentityService(
            IUserRepository userRepository, 
            IRoleRepository roleRepository, 
            IEncryptionService encryptionService,
            AuthenticatedUserService _aus,
            IMapper _mapper) : base(_mapper,_aus)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }
        public async Task<BaseResponse<TokenResponse>> GetToken(TokenRequest tokenRequest)
        {
            try
            {
                var user = new DataLayer.Entities.User();
                if (!string.IsNullOrEmpty(tokenRequest.Email))
                {
                    user = await _userRepository.GetUserByEmail(tokenRequest.Email);
                }
                else user = await _userRepository.GetUserByUsername(tokenRequest.UserName);
                if (user == null) return new BaseResponse<TokenResponse>(Get404("Kullanıcı Bulunamadı"));
                if (!user.IsActive) return new BaseResponse<TokenResponse>(Get404("Kullanıcı aktif değil"));
                if (user.IsBanned) return new BaseResponse<TokenResponse>(Get404($"Kullanıcı Yasaklı - Yasak bitiş: {string.Format(user.BannedUntil.ToString(), "DD.MM.YYYY HH:mm")} , Yasak nedeni : {user.BanReason} "));

                var password = _encryptionService.AESEncryptText(tokenRequest.Password, user.PasswordHash);
                if (password != user.Password)
                    return new BaseResponse<TokenResponse>(Get400("Kullanıcı adı, e-posta veya şifre hatalı"));

                JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
                var response = new TokenResponse();
                response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                response.User = new UserDto();
                response.User.Id = user.Id;
                response.User.UserName = user.UserName;
                response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                response.IssuedOn = jwtSecurityToken.ValidFrom.ToLocalTime();
                response.ExpiresOn = jwtSecurityToken.ValidTo.ToLocalTime();
                response.User.Email = user.Email;
                response.User.Avatar = user.Avatar;
                response.User.CreatedOn = user.CreatedOn;
                return new BaseResponse<TokenResponse>(response);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TokenResponse>(Get500(ex.Message)); 
            }
           
        }

        public async Task<BaseResponse<RegisterResponse>> Register(RegisterRequest request)
        {
            try
            {
                var emailCheck = await _userRepository.GetUserByEmail(request.Email);
                var nameCheck = await _userRepository.GetUserByUsername(request.UserName);
                if (emailCheck == null && nameCheck == null)
                {
                    var user = GetUserWithDefaultValues();
                    user.UserName = request.UserName;
                    user.Email = request.Email;
                    user.Avatar = request.Avatar;
                    user.PasswordHash = RandomTokenString();
                    user.SecurityStamp = RandomTokenString();
                    user.Password = _encryptionService.AESEncryptText(request.Password, user.PasswordHash);
                    user.Id = await _userRepository.AddUser(user);
                    var data = _mapper.Map<UserDto>(user);
                    return new BaseResponse<RegisterResponse> { Data = new RegisterResponse { User = data }, Success = true };
                }
                return new BaseResponse<RegisterResponse>(Get400("Bu e-posta veya kullanıcı adıyla bir kullanııcı zaten mevcut"));
            }
            catch (Exception ex)
            {
                return new BaseResponse<RegisterResponse>(Get500(ex.Message));
            }

            
        }
        public async Task<BaseResponse<bool>> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                var user= await _userRepository.GetUserById(request.UserId);
                if (user == null)
                    return new BaseResponse<bool>(Get404());
                var oldHash = _encryptionService.AESEncryptText( request.OldPassword, user.PasswordHash);
                if (oldHash != user.Password)
                    return new BaseResponse<bool>(Get400("Bilgiler eksik veya hatalı"));
                user.PasswordHash = RandomTokenString();
                user.Password= _encryptionService.AESEncryptText(request.NewPassword, user.PasswordHash);
                var result= await _userRepository.UpdateUser(user);
                    return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
           
        }
        private async Task<JwtSecurityToken> GenerateJWToken(DataLayer.Entities.User user)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim("uid", user.Id.ToString()),

            };
            return JWTGeneration(claims);
        }
        private JwtSecurityToken JWTGeneration(IEnumerable<Claim> claims)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2D4A614E645267556B58703273357638792F423F4428472B4B6250655368566D"));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "SingleOrDefault",
                audience: "SingleOrDefault",
                claims: claims,
                notBefore: DateTime.Now.ToLocalTime(),
                expires: DateTime.Now.ToLocalTime().AddHours(3),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider =  RandomNumberGenerator.Create();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
        private DataLayer.Entities.User GetUserWithDefaultValues()
        {
            var user=new DataLayer.Entities.User();
            user.IsEmailConfirmed = false;
            user.IsActive = true;
            user.CreatedBy = 1;
            user.CreatedOn = DateTime.Now;
            user.RoleId= 2;
            user.IsBanned = false;
            user.ReportedRating = 0;
            return user;
        }
    }
}
