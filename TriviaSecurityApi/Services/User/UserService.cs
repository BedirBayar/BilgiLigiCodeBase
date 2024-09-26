using AutoMapper;
using Azure.Core;
using TriviaSecurityApi.DataLayer.Repositories;
using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.UserModels;

namespace TriviaSecurityApi.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
     

        public async Task<BaseResponse<int>> AddUser(UserDto user)
        {
            var e= await _userRepository.GetUserByEmail(user.Email);
            var u= await _userRepository.GetUserByUsername(user.UserName);
            if(e==null && u == null)
            {
                var entity = _mapper.Map<DataLayer.Entities.User>(user);
                var result = await _userRepository.AddUser(entity);
                if (result > 0) return new BaseResponse<int>(result);
                else return new BaseResponse<int> { Error = new ErrorResponse { Code = "500",Message ="Bir hata oluştu" } }; 
            }
            return new BaseResponse<int> { Error = new ErrorResponse { Code = "400", Message = "Aynı E-Posta ya da kullanıcı adında kullanıcı mevcut." } };
        }

        public async Task<BaseResponse<int>> ArchiveUser(int id)
        {
            var u = await _userRepository.GetUserById(id);
            if ( u != null)
            {
                u.IsArchived = true;
                u.ArchivedOn = DateTime.Now;
                u.ArchivedBy = 2;
                var result = await _userRepository.UpdateUser(u);
                if (result > 0) return new BaseResponse<int>(result);
                else return new BaseResponse<int> { Error = new ErrorResponse { Code = "500", Message = "Bir hata oluştu" } };
            }
            return new BaseResponse<int> { Error = new ErrorResponse { Code = "404", Message = "Kullanıcı bulunamadı" } };
        }
    

        public async Task<BaseResponse<int>> BanUser(BanUserRequest request)
        {
            var u = await _userRepository.GetUserById(request.Id);
            if (u != null)
            {
                u.IsBanned = true;
                u.BannedUntil = DateTime.Now.AddDays(request.BanDays);
                u.BanReason = request.BanReason;
                var result = await _userRepository.UpdateUser(u);
                if (result > 0) return new BaseResponse<int>(result);
                else return new BaseResponse<int> { Error = new ErrorResponse { Code = "500", Message = "Bir hata oluştu" } };
            }
            return new BaseResponse<int> { Error = new ErrorResponse { Code = "404", Message = "Kullanıcı bulunamadı" } };
        }

        public async Task<BaseResponse<List<UserDto>>> GetAll()
        {
           var users = await _userRepository.GetAll();
            if (users != null)
            {
                var data = _mapper.Map<List<UserDto>>(users);
                return new BaseResponse<List<UserDto>> { Data = data };
            }
            return new BaseResponse<List<UserDto>> { Error = new ErrorResponse { Code = "404", Message = "Kullanıcı Bulunamadı" } };
        }

        public async Task<BaseResponse<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user != null)
            {
                var data = _mapper.Map<UserDto>(user);
                return new BaseResponse<UserDto> { Data = data };
            }
            return new BaseResponse<UserDto> { Error = new ErrorResponse { Code = "404", Message = "Kullanıcı Bulunamadı" } };
        }

        public async Task<BaseResponse<UserDto>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user != null)
            {
                var data = _mapper.Map<UserDto>(user);
                return new BaseResponse<UserDto> { Data = data };
            }
            return new BaseResponse<UserDto> { Error = new ErrorResponse { Code = "404", Message = "Kullanıcı Bulunamadı" } };
        }

        public async Task<BaseResponse<UserDto>> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user != null)
            {
                var data = _mapper.Map<UserDto>(user);
                return new BaseResponse<UserDto> { Data = data };
            }
            return new BaseResponse<UserDto> { Error = new ErrorResponse { Code = "404", Message = "Kullanıcı Bulunamadı" } };
        }

        public async Task<BaseResponse<int>> UpdateUser(UserDto user)
        {
            var u = await _userRepository.GetUserById(user.Id);
            if (u != null)
            {
                u.UserName = user.UserName;
                u.Avatar = user.Avatar;
                u.Email = user.Email;
                u.UpdatedOn= DateTime.Now;
                u.UpdatedBy = 2;
                var result = await _userRepository.UpdateUser(u);
                if (result > 0) return new BaseResponse<int>(result);
                else return new BaseResponse<int> { Error = new ErrorResponse { Code = "500", Message = "Bir hata oluştu" } };
            }
            return new BaseResponse<int> { Error = new ErrorResponse { Code = "404", Message = "Kullanıcı bulunamadı" } };
        }
    }
}
