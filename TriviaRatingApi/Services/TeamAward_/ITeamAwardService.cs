using TriviaRatingApi.DTOs;
using TriviaRatingApi.Models;
using TriviaRatingApi.Models.TeamModels;

namespace TriviaRatingApi.Services.TeamAward_
{
    public interface ITeamAwardService
    {
        Task<BaseResponse<List<TeamAwardDto>>> GetTeamAwards(int teamId);
        Task<BaseResponse<bool>> Delete(AddTeamAwardRequest request);
        Task<BaseResponse<bool>> Add(AddTeamAwardRequest request);
    }
}
