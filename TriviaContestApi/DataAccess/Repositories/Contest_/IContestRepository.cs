using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Contest_
{
    public interface IContestRepository
    {
        Task<List<Contest>> GetAll();
        Task<Contest> GetById(int id);
        Task<bool> Update(Contest contest);
        Task<int> Add(Contest contest);
    }
}
