using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.ContestRule_
{
    public interface IContestRuleRepository
    {
        Task<List<ContestRule>> GetAll();
        Task<ContestRule> GetById(int id);
        Task<bool> Update(ContestRule rule);
        Task<int> Add(ContestRule rule);
    }
}
