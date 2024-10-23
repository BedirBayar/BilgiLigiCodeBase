using Microsoft.EntityFrameworkCore;
using BilgiLigiRatingApi.DataLayer.Relationships;

namespace BilgiLigiRatingApi.DataLayer.Repositories.UserTeam_
{
    public class UserTeamRepository : IUserTeamRepository
    {
        private readonly IRatingDbContext _context;
        public UserTeamRepository(IRatingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(UserTeam ut)
        {
            _context.UserTeams.Add(ut);
            await _context.SaveChangesAsync();
            return ut.Id;
        }

        public async Task<bool> Delete(UserTeam ut)
        {
            _context.UserTeams.Remove(ut);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserTeam>> GetAll()
        {
            return await _context.UserTeams.ToListAsync();
        }

        public async Task<UserTeam> GetByUserAndTeam(int userId, int teamId)
        {
            return await _context.UserTeams.FirstOrDefaultAsync(t=>t.UserId==userId && t.TeamId==teamId);
        }
        public async Task<List<UserTeam>> GetByTeam(int id)
        {
            return await _context.UserTeams.Where(t=>t.TeamId==id).ToListAsync();
        }

        public async Task<List<UserTeam>> GetByUser(int id)
        {
            return await _context.UserTeams.Where(t => t.UserId == id).ToListAsync();
        }

        public async Task<bool> DeleteTeam(List<UserTeam> ut)
        {
            _context.UserTeams.RemoveRange(ut);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
