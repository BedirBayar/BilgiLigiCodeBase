using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserRank_
{
    public interface IUserRankRepository
    {
        Task<List<UserRank>> GetAll();
        Task<List<UserRank>> GetByRank(int rank);
        Task<UserRank> GetByTeam(int id);
        Task<bool> Update(UserRank tr);
        Task<int> Add(UserRank tr);
    }
}
