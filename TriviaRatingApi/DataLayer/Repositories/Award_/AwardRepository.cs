using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Entities;

namespace TriviaRatingApi.DataLayer.Repositories.Award_
{
    public class AwardRepository : IAwardRepository
    {
        private readonly IRatingDbContext _context;
        public AwardRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Award award)
        {
            _context.Awards.Add(award);
            await _context.SaveChangesAsync();
            return award.Id;
        }

        public async Task<List<Award>> GetAll()
        {
            return await _context.Awards.ToListAsync();
        }

        public async Task<Award> GetById(int id)
        {
            return await _context.Awards.FindAsync(id);
        }
        public async Task<Award> GetByNameAndType(string name, string type)
        {
            return await _context.Awards.FirstOrDefaultAsync(a=>a.Name.ToLower()==name.ToLower() && a.UserOrTeam==type);
        }

        public async Task<List<Award>> GetByIdList(List<int> ids)
        {
           return await _context.Awards.Where(a=>ids.Contains(a.Id)).ToListAsync();
        }

        public async Task<bool> Update(Award award)
        {
            _context.Awards.Update(award);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
