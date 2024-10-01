using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataAccess.Repositories.MatchQuestion_
{
    public class MatchQuestionRepository : IMatchQuestionRepository
    {
       
            private readonly IContestDbContext _context;

            public MatchQuestionRepository(IContestDbContext context)
            {
                _context = context;
            }
            public async Task<int> Add(MatchQuestion mq)
            {
                _context.MatchQuestions.Add(mq);
                await _context.SaveChangesAsync();
                return mq.Id;
            }
            public async Task<bool> AddRange(List<MatchQuestion> mq)
            {
                _context.MatchQuestions.AddRange(mq);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<List<MatchQuestion>> GetAll() => await _context.MatchQuestions.ToListAsync();

            public async Task<MatchQuestion> GetById(int id) => await _context.MatchQuestions.FindAsync(id);

            public async Task<bool> Update(MatchQuestion mq)
            {
                _context.MatchQuestions.Update(mq);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    
}
