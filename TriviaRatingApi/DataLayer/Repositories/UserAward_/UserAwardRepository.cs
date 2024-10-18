using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserAward_
{
    public class UserAwardRepository :IUserAwardRepository
    {
        private readonly IRatingDbContext _context;

        public UserAwardRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(UserAward tr)
        {
            _context.UserAwards.Add(tr);
            await _context.SaveChangesAsync();
            return tr.Id;
        }

        public async Task<List<UserAward>> GetAll()
        {
            return await _context.UserAwards.ToListAsync();
        }

        public async Task<List<UserAward>> GetByAward(int awardId)
        {
            return await _context.UserAwards.Where(t => t.AwardId == awardId).ToListAsync();
        }

        public async Task<List<UserAward>> GetByUser(int id)
        {
            return await _context.UserAwards.Where(t => t.UserId == id).ToListAsync();
        }
        public async Task<UserAward> GetByUserAndAward(int userId, int awardId)
        {
            return await _context.UserAwards.FirstOrDefaultAsync(t => t.UserId == userId && t.AwardId==awardId);
        }

        public async Task<bool> Update(UserAward tr)
        {
            _context.UserAwards.Update(tr);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(UserAward tr)
        {
            _context.UserAwards.Remove(tr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
