using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.ContestAward_
{
    public class ContestAwardRepository :IContestAwardRepository
    {
        private readonly IContestDbContext _context;
        public ContestAwardRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ContestAward award)
        {
            _context.ContestAwards.Add(award);
            await _context.SaveChangesAsync();
            return award.Id;
        }

        public async Task<List<ContestAward>> GetAll() => await _context.ContestAwards.ToListAsync();

        public async Task<ContestAward> GetById(int id) => await _context.ContestAwards.FindAsync(id);
        public async Task<ContestAward> GetByName(string name) => await _context.ContestAwards.FirstOrDefaultAsync(c=>c.Name==name);

        public async Task<bool> Update(ContestAward award)
        {
            _context.ContestAwards.Update(award);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
