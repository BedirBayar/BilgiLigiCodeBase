using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Entities;

namespace TriviaRatingApi.DataLayer.Repositories.Rank_
{
    public class RankRepository : IRankRepository
    {
        private readonly IRatingDbContext _context;
        public RankRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Rank rank)
        {
            _context.Ranks.Add(rank);
            await _context.SaveChangesAsync();
            return rank.Id;
        }

        public async Task<List<Rank>> GetAll()
        {
            return await _context.Ranks.IgnoreQueryFilters().ToListAsync();
        }
        public async Task<List<Rank>> GetAllActive()
        {
            return await _context.Ranks.Where(a=>a.IsActive).ToListAsync();
        }

        public async Task<List<Rank>> GetAllTeam()
        {
            return await _context.Ranks.Where(r=>r.UserOrTeam=="T" && r.IsActive).ToListAsync();
        }

        public async Task<List<Rank>> GetAllUser()
        {
            return await _context.Ranks.Where(r => r.UserOrTeam == "U" && r.IsActive).ToListAsync();
        }

        public async Task<List<Rank>> GetByDegree(int degree)
        {
            return await _context.Ranks.Where(r => r.Degree== degree && r.IsActive).ToListAsync();
        }

        public async Task<Rank> GetById(int id)
        {
            return await _context.Ranks.IgnoreQueryFilters().SingleOrDefaultAsync(r=>r.Id==id);
        }

        public async Task<Rank> GetByDegreeAndType(int degree, string type)
        {
            return await _context.Ranks.FirstOrDefaultAsync(r => r.Degree == degree && r.UserOrTeam== type && r.IsActive);
        }
      

        public async Task<bool> Update(Rank rank)
        {
           _context.Ranks.Update(rank);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
