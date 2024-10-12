using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Match_
{
    public interface IUserMatchRepository
    {
        Task<List<UserMatch>> GetAll();
        Task<UserMatch> GetById(int id);
        Task<List<UserMatch>> GetByIdList(List<int> ids);
        Task<bool> Update(UserMatch match);
        Task<int> Add(UserMatch match);
    }
}
