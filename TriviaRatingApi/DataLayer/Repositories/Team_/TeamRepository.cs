using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Entities;

namespace TriviaRatingApi.DataLayer.Repositories.Team_
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IRatingDbContext _context;
        public TeamRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Team team)
        {
           _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team.Id;
        }

        public async Task<List<Team>> GetAll()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team> GetById(int id)
        {
            return await  _context.Teams.FindAsync(id);
        }

        public async Task<Team> GetByName(string name)
        {
            return await _context.Teams.FirstOrDefaultAsync(t=>t.Name.ToLower()==name.ToLower());
        }

        public async Task<List<Team>> GetByRank(int rank)
        {
            var teamIds = await _context.TeamRanks.Where(tr => tr.RankDegree == rank).Select(tr => tr.TeamId).ToListAsync();
            return await _context.Teams.Where(t=>teamIds.Contains(t.Id)).ToListAsync();
        }

        public async Task<bool> Update(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
