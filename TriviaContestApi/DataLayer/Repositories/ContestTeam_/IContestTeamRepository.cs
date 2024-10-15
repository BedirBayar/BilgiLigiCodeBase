using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataLayer.Repositories.ContestTeam_
{
    public interface IContestTeamRepository
    {
        Task<ContestTeam> GetById(int id);
        Task<List<ContestTeam>> GetByContest(int contestId);
        Task<List<ContestTeam>> GetByTeam(int contestId);
        Task<int> Add(ContestTeam ct);
        Task<List<int>> AddRange(List<ContestTeam> cts);
    }
}
