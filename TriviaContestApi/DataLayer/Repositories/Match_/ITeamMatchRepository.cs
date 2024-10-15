using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Match_
{
    public interface ITeamMatchRepository
    {
        Task<List<TeamMatch>> GetAll();
        Task<List<TeamMatch>> GetByContest(int contestId);
        Task<List<TeamMatch>> GetByTeam(int teamId);
        Task<TeamMatch> GetById(int id);
        Task<List<TeamMatch>> GetByIdList(List<int> ids);
        Task<bool> Update(TeamMatch match);
        Task<int> Add(TeamMatch match);
    }
}
