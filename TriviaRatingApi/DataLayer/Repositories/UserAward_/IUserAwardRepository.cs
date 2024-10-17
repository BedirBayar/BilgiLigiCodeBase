using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserAward_
{
    public interface IUserAwardRepository
    {
        Task<int> Add(UserAward tr);
        Task<List<UserAward>> GetAll();
        Task<List<UserAward>> GetByAward(int awardId);
        Task<UserAward> GetByUser(int id);
        Task<bool> Update(UserAward tr);
    }
}
