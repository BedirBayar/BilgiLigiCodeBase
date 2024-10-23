using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;

namespace BilgiLigiRatingApi.Services.Award_
{
    public interface IAwardService
    {
        Task<BaseResponse<List<AwardDto>>> GetAll();
        Task<BaseResponse<List<AwardDto>>> GetAllActive();
        Task<BaseResponse<List<AwardDto>>> GetByIdList(List<int> ids);
        Task<BaseResponse<AwardDto>> GetById(int id);
        Task<BaseResponse<bool>> Update(AwardDto awardDto);
        Task<BaseResponse<bool>> ChangeStatus(int id);
        Task<BaseResponse<bool>> Archive(int id);
        Task<BaseResponse<int>> Add(AwardDto awardDto);
    }
}
