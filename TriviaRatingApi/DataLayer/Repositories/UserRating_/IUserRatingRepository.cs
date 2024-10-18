using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserRating_
{
    public interface IUserRatingRepository
    {
        Task<List<UserRating>> GetAll();
        Task<List<UserRating>> GetByRatingInterval(int min, int max);
        Task<UserRating> GetByUser(int id);
        Task<bool> Update(UserRating tr);
        Task<int> Add(UserRating tr);
        Task<bool> Delete(UserRating tr);
    }
}
