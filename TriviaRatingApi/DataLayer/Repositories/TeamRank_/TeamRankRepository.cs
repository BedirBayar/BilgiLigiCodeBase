using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Entities;
using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.TeamRank_
{
    public class TeamRankRepository : ITeamRankRepository
    {
        private readonly IRatingDbContext _context;

        public TeamRankRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(TeamRank tr)
        {
            _context.TeamRanks.Add(tr);
            await _context.SaveChangesAsync();
            return tr.TeamId;
        }

        public async Task<List<TeamRank>> GetAll()
        {
            return await _context.TeamRanks.ToListAsync();
        }

        public async Task<List<TeamRank>> GetByRank(int rank)
        {
            return await _context.TeamRanks.Where(t=>t.RankDegree == rank).ToListAsync();
        }

        public async Task<TeamRank> GetByTeam(int id)
        {
            return await _context.TeamRanks.FirstOrDefaultAsync(t => t.TeamId == id);
        }

        public async Task<bool> Update(TeamRank tr)
        {
            _context.TeamRanks.Update(tr);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(TeamRank tr)
        {
            _context.TeamRanks.Remove(tr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
