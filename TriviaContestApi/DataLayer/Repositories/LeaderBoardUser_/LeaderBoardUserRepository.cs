using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataAccess.Repositories.LeaderBoardUser_
{
    public class LeaderBoardUserRepository :ILeaderBoardUserRepository
    {
       
            private readonly IContestDbContext _context;

            public LeaderBoardUserRepository(IContestDbContext context)
            {
                _context = context;
            }
            public async Task<int> Add(LeaderBoardUser user)
            {
                _context.LeaderBoardUsers.Add(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
            public async Task<bool> AddRange(List<LeaderBoardUser> users)
            {
                _context.LeaderBoardUsers.AddRange(users);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<List<LeaderBoardUser>> GetAll() => await _context.LeaderBoardUsers.ToListAsync();

            public async Task<LeaderBoardUser> GetById(int id) => await _context.LeaderBoardUsers.FindAsync(id);

            public async Task<bool> Update(LeaderBoardUser user)
            {
                _context.LeaderBoardUsers.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    
}
