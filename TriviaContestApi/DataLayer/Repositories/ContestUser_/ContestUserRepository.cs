using TriviaContestApi.DataAccess.Relationships;
using TriviaContestApi.DataAccess;
using TriviaContestApi.DataLayer.Relationships;
using Microsoft.EntityFrameworkCore;

namespace TriviaContestApi.DataLayer.Repositories.ContestUser_
{
    public class ContestUserRepository : IContestUserRepository
    {
        private readonly IContestDbContext _context;
        public ContestUserRepository(IContestDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(ContestUser ct)
        {
            _context.ContestUsers.Add(ct);
            await _context.SaveChangesAsync();
            return ct.Id;
        }

        public async Task<List<int>> AddRange(List<ContestUser> cts)
        {
            _context.ContestUsers.AddRange(cts);
            await _context.SaveChangesAsync();
            return cts.Select(c => c.Id).ToList();
        }

        public async Task<List<ContestUser>> GetByContest(int contestId)
        {
            return await _context.ContestUsers.Where(t => t.ContestId == contestId).ToListAsync();
        }

        public async Task<ContestUser> GetById(int id)
        {
            return await _context.ContestUsers.FindAsync(id);
        }

        public async Task<List<ContestUser>> GetByUser(int userId)
        {
            return await _context.ContestUsers.Where(t => t.UserId == userId).ToListAsync();
        }
    }
}
