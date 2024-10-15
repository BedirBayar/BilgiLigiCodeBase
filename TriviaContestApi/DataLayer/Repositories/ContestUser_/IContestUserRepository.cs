using TriviaContestApi.DataAccess.Relationships;
using TriviaContestApi.DataLayer.Relationships;

namespace TriviaContestApi.DataLayer.Repositories.ContestUser_
{
    public interface IContestUserRepository
    {
        Task<ContestUser> GetById(int id);
        Task<List<ContestUser>> GetByContest(int contestId);
        Task<List<ContestUser>> GetByUser(int userId);
        Task<int> Add(ContestUser ct);
        Task<List<int>> AddRange(List<ContestUser> cts);
    }
}

