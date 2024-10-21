using Microsoft.EntityFrameworkCore;
using TriviaContributionApi.DataLayer.Relationships;

namespace TriviaContributionApi.DataLayer.Repositories.QuestionDifficulty_
{
    public class QuestionDifficultyRepository : IQuestionDifficultyRepository
    {
        private readonly IContributionDbContext _context;
        public QuestionDifficultyRepository(IContributionDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(QuestionDifficulty qu)
        {
            _context.QuestionDifficulties.Add(qu);
            await _context.SaveChangesAsync();
            return qu.Id;
        }

        public async Task<bool> Delete(QuestionDifficulty qu)
        {
            _context.QuestionDifficulties.Remove(qu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<QuestionDifficulty>> GetAll()
        {
           return await _context.QuestionDifficulties.ToListAsync();
        }

        public async Task<QuestionDifficulty> GetById(int id)
        {
            return await _context.QuestionDifficulties.FindAsync(id);
        }

        public async Task<List<QuestionDifficulty>> GetByQuestion(int questionId)
        {
            return await _context.QuestionDifficulties.Where(q=>q.QuestionId==questionId).ToListAsync();
        }

        public async Task<List<QuestionDifficulty>> GetByUser(int userId)
        {
            return await _context.QuestionDifficulties.Where(q => q.CreatedBy == userId).ToListAsync();
        }

        public async Task<bool> Update(QuestionDifficulty qu)
        {
            _context.QuestionDifficulties.Update(qu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
