using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataLayer.Repositories.ContestRule_
{
    public interface IContestRuleRepository
    {
        Task<List<ContestRule>> GetAll();
        Task<List<ContestRule>> GetAllActive();
        Task<List<ContestRule>> GetByContestType(int cTypeId);
        Task<List<ContestRule>> GetByContestTypeAndOrder(int cTypeId,int order);
        Task<ContestRule> GetById(int id);
        Task<int> Add(ContestRule contestRule);
        Task<bool> Update(ContestRule contestRule);
    }
}
