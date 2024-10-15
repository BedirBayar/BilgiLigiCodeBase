using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.Match_
{
    public interface ITeamMatchService
    {
        Task<BaseResponse<List<TeamMatchDto>>> GetAll();
        Task<BaseResponse<List<TeamMatchDto>>> GetByContest(int contestId);
        Task<BaseResponse<List<TeamMatchDto>>> GetByTeam(int teamId);
        Task<BaseResponse<TeamMatchDto>> GetById(int id);
    }
}
