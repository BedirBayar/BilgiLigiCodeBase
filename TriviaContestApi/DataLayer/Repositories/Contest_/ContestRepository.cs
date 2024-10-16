using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Contest_
{
    public class ContestRepository : IContestRepository
    {
        private readonly IContestDbContext _context;
        public ContestRepository(IContestDbContext context) { 
            _context = context;
        }
        public async Task<int> Add(Contest contest)
        {
            _context.Contests.Add(contest);
            await _context.SaveChangesAsync();
            return contest.Id;
        }

        public async Task<List<Contest>> GetAll() => await _context.Contests.ToListAsync();
        public async Task<List<Contest>> GetAllUnfinished() => await _context.Contests.Where(c=>c.EndDate>DateTime.Now).ToListAsync();

        public async Task<Contest> GetById(int id) => await _context.Contests.FindAsync(id);
        public async Task<Contest> GetByName(string name) => await _context.Contests.FirstOrDefaultAsync(c=>c.Name.ToLower()==name.ToLower());

        public async Task<bool> Update(Contest contest)
        {
            _context.Contests.Update(contest);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
