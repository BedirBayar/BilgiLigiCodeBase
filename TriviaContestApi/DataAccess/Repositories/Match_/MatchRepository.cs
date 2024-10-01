using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Match_
{
    public class MatchRepository:IMatchRepository
    {
        private readonly IContestDbContext _context;
        public MatchRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return match.Id;
        }

        public async Task<List<Match>> GetAll() => await _context.Matches.ToListAsync();

        public async Task<Match> GetById(int id) => await _context.Matches.FindAsync(id);
        public async Task<List<Match>> GetByIdList(List<int> ids) => await _context.Matches.Where(m=>ids.Contains(m.Id)).ToListAsync();

        public async Task<bool> Update(Match match)
        {
            _context.Matches.Update(match);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
