using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataAccess.Repositories.MatchQuestion_
{
    public class UserMatchQuestionRepository : IUserMatchQuestionRepository
    {
       
            private readonly IContestDbContext _context;

            public UserMatchQuestionRepository(IContestDbContext context)
            {
                _context = context;
            }
            public async Task<int> Add(UserMatchQuestion mq)
            {
                _context.UserMatchQuestions.Add(mq);
                await _context.SaveChangesAsync();
                return mq.Id;
            }
            public async Task<bool> AddRange(List<UserMatchQuestion> mq)
            {
                _context.UserMatchQuestions.AddRange(mq);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<List<UserMatchQuestion>> GetAll() => await _context.UserMatchQuestions.ToListAsync();

            public async Task<UserMatchQuestion> GetById(int id) => await _context.UserMatchQuestions.FindAsync(id);

            public async Task<bool> Update(UserMatchQuestion mq)
            {
                _context.UserMatchQuestions.Update(mq);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    
}
