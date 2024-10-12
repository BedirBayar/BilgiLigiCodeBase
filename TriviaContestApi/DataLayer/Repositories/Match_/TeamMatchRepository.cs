using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Match_
{
    public class TeamMatchRepository: ITeamMatchRepository
    {
        private readonly IContestDbContext _context;
        public TeamMatchRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(TeamMatch match)
        {
            _context.TeamMatches.Add(match);
            await _context.SaveChangesAsync();
            return match.Id;
        }

        public async Task<List<TeamMatch>> GetAll() => await _context.TeamMatches.ToListAsync();

        public async Task<TeamMatch> GetById(int id) => await _context.TeamMatches.FindAsync(id);
        public async Task<List<TeamMatch>> GetByIdList(List<int> ids) => await _context.TeamMatches.Where(m=>ids.Contains(m.Id)).ToListAsync();

        public async Task<bool> Update(TeamMatch match)
        {
            _context.TeamMatches.Update(match);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
