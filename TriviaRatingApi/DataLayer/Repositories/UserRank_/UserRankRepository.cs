using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserRank_
{
    public class UserRankRepository :IUserRankRepository
    {
        private readonly IRatingDbContext _context;

        public UserRankRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(UserRank tr)
        {
            _context.UserRanks.Add(tr);
            await _context.SaveChangesAsync();
            return tr.UserId;
        }

        public async Task<List<UserRank>> GetAll()
        {
            return await _context.UserRanks.ToListAsync();
        }

        public async Task<List<UserRank>> GetByRank(int rank)
        {
            return await _context.UserRanks.Where(t => t.RankDegree == rank).ToListAsync();
        }

        public async Task<UserRank> GetByUser(int id)
        {
            return await _context.UserRanks.FirstOrDefaultAsync(t => t.UserId == id);
        }

        public async Task<bool> Update(UserRank tr)
        {
            _context.UserRanks.Update(tr);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(UserRank tr)
        {
            _context.UserRanks.Remove(tr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
