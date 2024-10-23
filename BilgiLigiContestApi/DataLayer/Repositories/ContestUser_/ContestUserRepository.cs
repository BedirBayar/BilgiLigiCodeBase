using BilgiLigiContestApi.DataAccess.Relationships;
using BilgiLigiContestApi.DataAccess;
using BilgiLigiContestApi.DataLayer.Relationships;
using Microsoft.EntityFrameworkCore;

namespace BilgiLigiContestApi.DataLayer.Repositories.ContestUser_
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

        public async Task<ContestUser> GetByUserAndContest(int userId, int contestId)
        {
            return await _context.ContestUsers.FirstOrDefaultAsync(u=>u.UserId==userId&&u.ContestId==contestId);
        }

        public async Task<List<ContestUser>> GetByUser(int userId)
        {
            return await _context.ContestUsers.Where(t => t.UserId == userId).ToListAsync();
        }
        public async Task<int> Delete(ContestUser ct)
        {
            _context.ContestUsers.Remove(ct);
            return await _context.SaveChangesAsync();
        }
    }
}
