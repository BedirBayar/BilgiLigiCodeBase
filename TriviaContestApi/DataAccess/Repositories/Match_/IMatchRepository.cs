using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Match_
{
    public interface IMatchRepository
    {
        Task<List<Match>> GetAll();
        Task<Match> GetById(int id);
        Task<List<Match>> GetByIdList(List<int> ids);
        Task<bool> Update(Match match);
        Task<int> Add(Match match);
    }
}
