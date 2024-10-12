using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataAccess.Repositories.MatchQuestion_
{
    public class TeamMatchQuestionRepository : ITeamMatchQuestionRepository
    {
       
            private readonly IContestDbContext _context;

            public TeamMatchQuestionRepository(IContestDbContext context)
            {
                _context = context;
            }
            public async Task<int> Add(TeamMatchQuestion mq)
            {
                _context.TeamMatchQuestions.Add(mq);
                await _context.SaveChangesAsync();
                return mq.Id;
            }
            public async Task<bool> AddRange(List<TeamMatchQuestion> mq)
            {
                _context.TeamMatchQuestions.AddRange(mq);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<List<TeamMatchQuestion>> GetAll() => await _context.TeamMatchQuestions.ToListAsync();

            public async Task<TeamMatchQuestion> GetById(int id) => await _context.TeamMatchQuestions.FindAsync(id);

            public async Task<bool> Update(TeamMatchQuestion mq)
            {
                _context.TeamMatchQuestions.Update(mq);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    
}
