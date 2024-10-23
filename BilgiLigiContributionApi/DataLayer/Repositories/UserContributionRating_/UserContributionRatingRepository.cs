using Microsoft.EntityFrameworkCore;
using BilgiLigiContributionApi.DataLayer.Relationships;

namespace BilgiLigiContributionApi.DataLayer.Repositories.UserContributionRating_
{
    public class UserContributionRatingRepository 
        : IUserContributionRatingRepository
    {
        private readonly IContributionDbContext _context;
        public UserContributionRatingRepository(IContributionDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(UserContributionRating rating)
        {
            _context.UserContributionRatings.Add(rating);
            await _context.SaveChangesAsync();
            return rating.UserId;
        }

        public async Task<bool> Delete(UserContributionRating rating)
        {
            _context.UserContributionRatings.Remove(rating);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserContributionRating>> GetAll()
        {
            return await _context.UserContributionRatings.ToListAsync();
        }

        public async Task<List<UserContributionRating>> GetByRatingInterval(int min, int max)
        {
           return await _context.UserContributionRatings.Where(r=>r.ContributionRating>=min && r.ContributionRating<=max).ToListAsync();
        }

        public async Task<UserContributionRating> GetByUser(int id)
        {
            return await _context.UserContributionRatings.FindAsync(id);
        }

        public async Task<List<UserContributionRating>> GetTopN(int n)
        {
            return await _context.UserContributionRatings.OrderByDescending(r=>r.ContributionRating).Take(n).ToListAsync();
        }

        public async Task<bool> Update(UserContributionRating rating)
        {
            _context.UserContributionRatings.Update(rating);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
