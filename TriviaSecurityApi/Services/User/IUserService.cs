using TriviaSecurityApi.DTOs.UserModels;
using TriviaSecurityApi.DTOs;

namespace TriviaSecurityApi.Services.User
{
    public interface IUserService
    {
        Task<BaseResponse<List<UserDto>>> GetAll();
        Task<BaseResponse<UserDto>> GetUserById(int id);
        Task<BaseResponse<UserDto>> GetUserByEmail(string email);
        Task<BaseResponse<UserDto>> GetUserByUsername(string username);
        Task<BaseResponse<int>> UpdateUser(UserDto user);
        Task<BaseResponse<int>> AddUser(UserDto user);
        Task<BaseResponse<int>> ArchiveUser(int id);
        Task<BaseResponse<int>> BanUser(BanUserRequest request);
    }
}
