using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;

namespace BilgiLigiRatingApi.Services.UserRating_
{
    public interface IUserRatingService
    {
        Task<BaseResponse<List<UserRatingDto>>> GetAll();
        Task<BaseResponse<List<UserRatingDto>>> GetByRatingInterval(int min, int max);
        Task<BaseResponse<UserRatingDto>> GetByUser(int id);
        Task<BaseResponse<int>> Add(UserRatingDto request);
        Task<BaseResponse<bool>> Update(UserRatingDto request);
        Task<BaseResponse<bool>> Delete(int userId);
    }
}
