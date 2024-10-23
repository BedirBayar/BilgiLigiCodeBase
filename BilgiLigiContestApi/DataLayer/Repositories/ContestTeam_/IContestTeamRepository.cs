using BilgiLigiContestApi.DataAccess.Entities;
using BilgiLigiContestApi.DataAccess.Relationships;
using BilgiLigiContestApi.DataLayer.Relationships;

namespace BilgiLigiContestApi.DataLayer.Repositories.ContestTeam_
{
    public interface IContestTeamRepository
    {
        Task<ContestTeam> GetByTeamAndContest(int userId, int contestId);
        Task<List<ContestTeam>> GetByContest(int contestId);
        Task<List<ContestTeam>> GetByTeam(int contestId);
        Task<int> Add(ContestTeam ct);
        Task<List<int>> AddRange(List<ContestTeam> cts);
        Task<int> Delete(ContestTeam ct);
    }
}
