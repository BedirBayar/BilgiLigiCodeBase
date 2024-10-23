using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;

namespace BilgiLigiRatingApi.Services.TeamRating_
{
    public interface ITeamRatingService
    {
        Task<BaseResponse<List<TeamRatingDto>>> GetAll();
        Task<BaseResponse<List<TeamRatingDto>>> GetByRatingInterval(int min, int max);
        Task<BaseResponse<TeamRatingDto>> GetByTeam(int teamId);
        Task<BaseResponse<int>> Add(TeamRatingDto teamRatingDto);
        Task<BaseResponse<bool>> Update(TeamRatingDto teamRatingDto);
        Task<BaseResponse<bool>> Delete(int id);
    }
}
