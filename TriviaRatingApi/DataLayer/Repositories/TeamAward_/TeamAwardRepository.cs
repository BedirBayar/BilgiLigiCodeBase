using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.TeamAward_
{
    public class TeamAwardRepository :ITeamAwardRepository
    {
        private readonly IRatingDbContext _context;
        public TeamAwardRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(TeamAward tr)
        {
            _context.TeamAwards.Add(tr);
            await _context.SaveChangesAsync();
            return tr.Id;
        }
        public async Task<List<TeamAward>> GetAll()
        {
            return await _context.TeamAwards.ToListAsync();
        }
        public async Task<List<TeamAward>> GetByAward(int awardId)
        {
            return await _context.TeamAwards.Where(t => t.AwardId == awardId).ToListAsync();
        }
        public async Task<TeamAward> GetByTeam(int id)
        {
            return await _context.TeamAwards.FirstOrDefaultAsync(t => t.TeamId == id);
        }
        public async Task<bool> Update(TeamAward tr)
        {
            _context.TeamAwards.Update(tr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
