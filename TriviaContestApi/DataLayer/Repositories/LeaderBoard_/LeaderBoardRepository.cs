using TriviaContestApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace TriviaContestApi.DataAccess.Repositories.LeaderBoard_
{
    public class LeaderBoardRepository 
        : ILeaderBoardRepository
    {
        private readonly IContestDbContext _context;

        public LeaderBoardRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(LeaderBoard board)
        {
            _context.LeaderBoards.Add(board);
            await _context.SaveChangesAsync();
            return board.Id;
        }

        public async Task<List<LeaderBoard>> GetAll() => await _context.LeaderBoards.ToListAsync();
        public async Task<List<LeaderBoard>> GetAllIncomplete() => await _context.LeaderBoards.Where(l=>l.IsComplete==false).ToListAsync();

        public async Task<LeaderBoard> GetById(int id) => await _context.LeaderBoards.FindAsync(id);

        public async Task<bool> Update(LeaderBoard board)
        {
            _context.LeaderBoards.Update(board);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
