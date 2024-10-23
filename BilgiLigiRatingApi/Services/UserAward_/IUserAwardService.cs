using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Models.UserModels;

namespace BilgiLigiRatingApi.Services.UserAward_
{
    public interface IUserAwardService
    {
        Task<BaseResponse<List<UserAwardDto>>> GetUserAwards(int userId);
        Task<BaseResponse<bool>> Delete(AddUserAwardRequest request);
        Task<BaseResponse<int>> Add(AddUserAwardRequest request);
    }
}
