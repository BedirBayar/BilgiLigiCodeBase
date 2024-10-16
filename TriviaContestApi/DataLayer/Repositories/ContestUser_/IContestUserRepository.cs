using TriviaContestApi.DataAccess.Relationships;
using TriviaContestApi.DataLayer.Relationships;

namespace TriviaContestApi.DataLayer.Repositories.ContestUser_
{
    public interface IContestUserRepository
    {
        Task<ContestUser> GetByUserAndContest(int userId,int contestId);
        Task<List<ContestUser>> GetByContest(int contestId);
        Task<List<ContestUser>> GetByUser(int userId);
        Task<int> Add(ContestUser cu);
        Task<List<int>> AddRange(List<ContestUser> cus);
        Task<int> Delete(ContestUser cu);
    }
}

