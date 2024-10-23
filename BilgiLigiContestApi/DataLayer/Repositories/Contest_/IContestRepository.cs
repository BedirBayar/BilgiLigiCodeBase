using BilgiLigiContestApi.DataAccess.Entities;

namespace BilgiLigiContestApi.DataAccess.Repositories.Contest_
{
    public interface IContestRepository
    {
        Task<List<Contest>> GetAll();
        Task<List<Contest>> GetAllUnfinished();
        Task<Contest> GetById(int id);
        Task<Contest> GetByName(string name);
        Task<bool> Update(Contest contest);
        Task<int> Add(Contest contest);
    }
}
