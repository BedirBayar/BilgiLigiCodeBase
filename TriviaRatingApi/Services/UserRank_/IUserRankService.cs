using TriviaRatingApi.DTOs;
using TriviaRatingApi.Models;
using TriviaRatingApi.Models.UserModels;

namespace TriviaRatingApi.Services.UserRank_
{
    public interface IUserRankService
    {
        Task<BaseResponse<List<UserRankDto>>> GetAll();
        Task<BaseResponse<List<UserRankDto>>> GetByRank(int rank);
        Task<BaseResponse<UserRankDto>> GetByUser(int id);
        Task<BaseResponse<int>>Add(AddUserRankRequest request);
        Task<BaseResponse<bool>>Update(AddUserRankRequest request);
        Task<BaseResponse<bool>>Delete(int userId);
    }
}
