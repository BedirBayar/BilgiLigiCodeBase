using BilgiLigiContestApi.DTOs;

namespace BilgiLigiContestApi.Services.Match_
{
    public interface ITeamMatchService
    {
        Task<BaseResponse<List<TeamMatchDto>>> GetAll();
        Task<BaseResponse<List<TeamMatchDto>>> GetByContest(int contestId);
        Task<BaseResponse<List<TeamMatchDto>>> GetByTeam(int teamId);
        Task<BaseResponse<TeamMatchDto>> GetById(int id);
    }
}
