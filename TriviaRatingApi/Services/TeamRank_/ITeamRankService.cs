using TriviaRatingApi.DTOs;
using TriviaRatingApi.Models;

namespace TriviaRatingApi.Services.TeamRank_
{
    public interface ITeamRankService
    {
        Task<BaseResponse<List<TeamRankDto>>> GetAll();
        Task<BaseResponse<TeamRankDto>> GetTeamRank(int teamId);
        Task<BaseResponse<bool>>Update(TeamRankDto teamRankDto);
        Task<BaseResponse<int>>Add(TeamRankDto teamRankDto);
        Task<BaseResponse<bool>>Delete(TeamRankDto teamRankDto);
    }
}
