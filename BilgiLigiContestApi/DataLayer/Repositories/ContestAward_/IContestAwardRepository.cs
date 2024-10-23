using BilgiLigiContestApi.DataAccess.Entities;

namespace BilgiLigiContestApi.DataAccess.Repositories.ContestAward_
{
    public interface IContestAwardRepository
    {
        Task<List<ContestAward>> GetAll();
        Task<ContestAward> GetById(int id);
        Task<List<ContestAward>> GetByContest(int contestId);
        Task<bool> Update(ContestAward award);
        Task<int> Add(ContestAward award);
    }
}
