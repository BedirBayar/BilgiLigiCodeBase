using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Models.TeamModels;

namespace BilgiLigiRatingApi.Services.TeamAward_
{
    public interface ITeamAwardService
    {
        Task<BaseResponse<List<TeamAwardDto>>> GetTeamAwards(int teamId);
        Task<BaseResponse<bool>> Delete(AddTeamAwardRequest request);
        Task<BaseResponse<bool>> Add(AddTeamAwardRequest request);
    }
}
