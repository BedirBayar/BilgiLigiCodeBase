using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.TeamRating_
{
    public class TeamRatingRepository : ITeamRatingRepository
    {
        private readonly IRatingDbContext _context;

        public TeamRatingRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(TeamRating tr)
        {
            _context.TeamRatings.Add(tr);
            await _context.SaveChangesAsync();
            return tr.TeamId;
        }

        public async Task<List<TeamRating>> GetAll()
        {
            return await _context.TeamRatings.ToListAsync();
        }

        public async Task<List<TeamRating>> GetByRating(int min, int max)
        {
            return await _context.TeamRatings.Where(t => t.Rating>=min && t.Rating <=max).ToListAsync();
        }

        public async Task<TeamRating> GetByTeam(int id)
        {
            return await _context.TeamRatings.FirstOrDefaultAsync(t => t.TeamId == id);
        }

        public async Task<bool> Update(TeamRating tr)
        {
            _context.TeamRatings.Update(tr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
