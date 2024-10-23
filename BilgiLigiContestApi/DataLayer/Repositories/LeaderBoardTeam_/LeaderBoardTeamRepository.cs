using Microsoft.EntityFrameworkCore;
using BilgiLigiContestApi.DataAccess.Entities;
using BilgiLigiContestApi.DataAccess.Relationships;

namespace BilgiLigiContestApi.DataAccess.Repositories.LeaderBoardTeam_
{
    public class LeaderBoardTeamRepository :ILeaderBoardTeamRepository
    {
        private readonly IContestDbContext _context;

        public LeaderBoardTeamRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(LeaderBoardTeam team)
        {
            _context.LeaderBoardTeams.Add(team);
            await _context.SaveChangesAsync();
            return team.Id;
        }
        public async Task<bool> AddRange(List<LeaderBoardTeam> teams)
        {
            _context.LeaderBoardTeams.AddRange(teams);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<LeaderBoardTeam>> GetAll() => await _context.LeaderBoardTeams.ToListAsync();

        public async Task<LeaderBoardTeam> GetById(int id) => await _context.LeaderBoardTeams.FindAsync(id);

        public async Task<bool> Update(LeaderBoardTeam team)
        {
            _context.LeaderBoardTeams.Update(team);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
