using Microsoft.EntityFrameworkCore;
using BilgiLigiContributionApi.DataLayer.Relationships;

namespace BilgiLigiContributionApi.DataLayer.Repositories.QuestionDraftDifficulty_
{
    public class DraftDifficultyRepository : IDraftDifficultyRepository
    {
        private readonly IContributionDbContext _context;
        public DraftDifficultyRepository(IContributionDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(QuestionDraftDifficulty qu)
        {
            _context.QuestionDraftDifficulties.Add(qu);
            await _context.SaveChangesAsync();
            return qu.Id;
        }

        public async Task<bool> Delete(QuestionDraftDifficulty qu)
        {
            _context.QuestionDraftDifficulties.Remove(qu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<QuestionDraftDifficulty>> GetAll()
        {
           return await _context.QuestionDraftDifficulties.ToListAsync();
        }

        public async Task<QuestionDraftDifficulty> GetById(int id)
        {
            return await _context.QuestionDraftDifficulties.FindAsync(id);
        }
        public async Task<QuestionDraftDifficulty> GetByUserAndQuestion(int userId, int questionId)
        {
            return await _context.QuestionDraftDifficulties.SingleOrDefaultAsync(q=>q.CreatedBy==userId&&q.QuestionDraftId==questionId);
        }

        public async Task<List<QuestionDraftDifficulty>> GetByQuestion(int questionId)
        {
            return await _context.QuestionDraftDifficulties.Where(q=>q.QuestionDraftId==questionId).ToListAsync();
        }

        public async Task<List<QuestionDraftDifficulty>> GetByUser(int userId)
        {
            return await _context.QuestionDraftDifficulties.Where(q => q.CreatedBy == userId).ToListAsync();
        }

        public async Task<bool> Update(QuestionDraftDifficulty qu)
        {
            _context.QuestionDraftDifficulties.Update(qu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
