using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Match_
{
    public class UserMatchRepository: IUserMatchRepository
    {
        private readonly IContestDbContext _context;
        public UserMatchRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(UserMatch match)
        {
            _context.UserMatches.Add(match);
            await _context.SaveChangesAsync();
            return match.Id;
        }

        public async Task<List<UserMatch>> GetAll() => await _context.UserMatches.ToListAsync();
        public async Task<List<UserMatch>> GetByContest(int contestId) => await _context.UserMatches.Where(m=>m.ContestId==contestId).ToListAsync();
        public async Task<List<UserMatch>> GetByUser(int userId) => await _context.UserMatches.Where(m=>m.User1Id==userId || m.User2Id==userId).ToListAsync();

        public async Task<UserMatch> GetById(int id) => await _context.UserMatches.FindAsync(id);
        public async Task<List<UserMatch>> GetByIdList(List<int> ids) => await _context.UserMatches.Where(m=>ids.Contains(m.Id)).ToListAsync();

        public async Task<bool> Update(UserMatch match)
        {
            _context.UserMatches.Update(match);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
