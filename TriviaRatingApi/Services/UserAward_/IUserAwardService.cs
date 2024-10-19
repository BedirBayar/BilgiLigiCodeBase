using TriviaRatingApi.DTOs;
using TriviaRatingApi.Models;
using TriviaRatingApi.Models.UserModels;

namespace TriviaRatingApi.Services.UserAward_
{
    public interface IUserAwardService
    {
        Task<BaseResponse<List<UserAwardDto>>> GetUserAwards(int userId);
        Task<BaseResponse<bool>> Delete(AddUserAwardRequest request);
        Task<BaseResponse<int>> Add(AddUserAwardRequest request);
    }
}
