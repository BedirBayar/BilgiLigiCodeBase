using BilgiLigiContributionApi.DataLayer.Relationships;

namespace BilgiLigiContributionApi.DataLayer.Repositories.UserContributionRating_
{
    public interface IUserContributionRatingRepository
    {
        Task<List<UserContributionRating>> GetAll();
        Task<List<UserContributionRating>> GetTopN(int n);
        Task<List<UserContributionRating>> GetByRatingInterval(int min, int max);
        Task<UserContributionRating> GetByUser(int id);
        Task<int> Add(UserContributionRating rating);
        Task<bool> Update(UserContributionRating rating);
        Task<bool> Delete(UserContributionRating rating);
        

    }
}
