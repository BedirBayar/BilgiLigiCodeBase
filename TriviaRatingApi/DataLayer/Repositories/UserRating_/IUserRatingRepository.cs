using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserRating_
{
    public interface IUserRatingRepository
    {
        Task<List<UserRating>> GetAll();
        Task<List<UserRating>> GetByRating(int min, int max);
        Task<UserRating> GetByTeam(int id);
        Task<bool> Update(UserRating tr);
        Task<int> Add(UserRating tr);
    }
}
