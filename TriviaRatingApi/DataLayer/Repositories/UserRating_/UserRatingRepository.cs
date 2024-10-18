using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserRating_
{
    public class UserRatingRepository :IUserRatingRepository
    {
        private readonly IRatingDbContext _context;

        public UserRatingRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(UserRating tr)
        {
            _context.UserRatings.Add(tr);
            await _context.SaveChangesAsync();
            return tr.UserId;
        }

        public async Task<List<UserRating>> GetAll()
        {
            return await _context.UserRatings.ToListAsync();
        }

        public async Task<List<UserRating>> GetByRatingInterval(int min, int max)
        {
            return await _context.UserRatings.Where(t => t.Rating >= min && t.Rating <= max).ToListAsync();
        }

        public async Task<UserRating> GetByUser(int id)
        {
            return await _context.UserRatings.FirstOrDefaultAsync(t => t.UserId == id);
        }

        public async Task<bool> Update(UserRating tr)
        {
            _context.UserRatings.Update(tr);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(UserRating tr)
        {
            _context.UserRatings.Remove(tr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
