using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserAward_
{
    public interface IUserAwardRepository
    {
        Task<int> Add(UserAward tr);
        Task<List<UserAward>> GetAll();
        Task<List<UserAward>> GetByAward(int awardId);
        Task<List<UserAward>> GetByUser(int id);
        Task<UserAward> GetByUserAndAward(int userId, int awardId);
        Task<bool> Update(UserAward tr);
        Task<bool> Delete(UserAward tr);
    }
}
