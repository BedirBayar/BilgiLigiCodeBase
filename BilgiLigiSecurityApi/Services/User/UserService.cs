using AutoMapper;
using Azure.Core;
using BilgiLigiContestApi.Services;
using BilgiLigiSecurityApi.DataLayer.Repositories;
using BilgiLigiSecurityApi.DTOs;
using BilgiLigiSecurityApi.DTOs.UserModels;

namespace BilgiLigiSecurityApi.Services.User
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMapper _mapper) :base(_mapper)
        {
            _userRepository = userRepository;
        }
     

        public async Task<BaseResponse<int>> AddUser(UserDto user)
        {
            try
            {
                var e = await _userRepository.GetUserByEmail(user.Email);
                var u = await _userRepository.GetUserByUsername(user.UserName);
                if (e != null || u != null) return new BaseResponse<int>(Get400("Aynı E-Posta ya da kullanıcı adında kullanıcı mevcut."));
                var entity = _mapper.Map<DataLayer.Entities.User>(user);
                var result = await _userRepository.AddUser(entity);
                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> ArchiveUser(int id)
        {
            try
            {
                var u = await _userRepository.GetUserById(id);
                if (u == null)
                    return new BaseResponse<bool>(Get400("Kullanıcı bulunamadı"));

                u.IsArchived = true;
                u.ArchivedOn = DateTime.Now;
                u.ArchivedBy = 1;
                var result = await _userRepository.UpdateUser(u);
                return new BaseResponse<bool>(result);

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
           
        }
    

        public async Task<BaseResponse<bool>> BanUser(BanUserRequest request)
        {
            try
            {
                var u = await _userRepository.GetUserById(request.UserId);
                if (u == null) return new BaseResponse<bool>(Get404("Kullanıcı bulunamadı"));
                if (request.IsUnbanRequest)
                {
                    u.IsBanned = false;
                    u.BannedUntil = DateTime.Now;
                }
                else
                {
                    u.IsBanned = true;
                    u.BannedUntil = DateTime.Now.AddDays(request.BanDays);
                    u.BanReason = request.BanReason;
                }
                var result = await _userRepository.UpdateUser(u);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
           
            
        }

        public async Task<BaseResponse<List<UserDto>>> GetAll()
        {
            try
            {
                var users = await _userRepository.GetAll();
                if (users == null) return new BaseResponse<List<UserDto>>(Get404("Kullanıcı Bulunamadı"));
                var data = _mapper.Map<List<UserDto>>(users);
                return new BaseResponse<List<UserDto>>(data);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserDto>>(Get500(ex.Message)); 
            }
           
        }

        public async Task<BaseResponse<UserDto>> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(email);
                if (user == null) return new BaseResponse<UserDto>(Get404("Kullanıcı Bulunamadı"));
                var data = _mapper.Map<UserDto>(user);
                return new BaseResponse<UserDto>(data);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserDto>(Get500(ex.Message));
            }
           
        }

        public async Task<BaseResponse<UserDto>> GetUserById(int id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);
                if (user == null) return new BaseResponse<UserDto>(Get404("Kullanıcı Bulunamadı"));
                var data = _mapper.Map<UserDto>(user);
                return new BaseResponse<UserDto>(data);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserDto>(Get500(ex.Message));
            }
            
        }

        public async Task<BaseResponse<UserDto>> GetUserByUsername(string username)
        {
            try
            {
                var user = await _userRepository.GetUserByUsername(username);
                if (user == null) return new BaseResponse<UserDto>(Get404("Kullanıcı Bulunamadı"));
                var data = _mapper.Map<UserDto>(user);
                return new BaseResponse<UserDto>(data);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserDto>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> UpdateUser(UserDto user)
        {
            try
            {
                var u = await _userRepository.GetUserById(user.Id);
                if (u == null) return new BaseResponse<bool>(Get404("Kullanıcı Bulunamadı"));
                u.UserName = user.UserName;
                u.Avatar = user.Avatar;
                u.Email = user.Email;
                u.UpdatedOn = DateTime.Now;
                u.UpdatedBy = 1;
                var result = await _userRepository.UpdateUser(u);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
            
        }
    }
}
