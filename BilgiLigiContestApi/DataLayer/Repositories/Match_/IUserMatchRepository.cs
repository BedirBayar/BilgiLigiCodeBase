using BilgiLigiContestApi.DataAccess.Entities;

namespace BilgiLigiContestApi.DataAccess.Repositories.Match_
{
    public interface IUserMatchRepository
    {
        Task<List<UserMatch>> GetAll();
        Task<List<UserMatch>> GetByContest(int contestId);
        Task<List<UserMatch>> GetByUser(int userId);
        Task<UserMatch> GetById(int id);
        Task<List<UserMatch>> GetByIdList(List<int> ids);
        Task<bool> Update(UserMatch match);
        Task<int> Add(UserMatch match);
    }
}
