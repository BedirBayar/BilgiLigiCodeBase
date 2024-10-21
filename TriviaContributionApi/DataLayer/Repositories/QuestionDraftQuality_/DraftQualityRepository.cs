using Microsoft.EntityFrameworkCore;
using TriviaContributionApi.DataLayer.Relationships;

namespace TriviaContributionApi.DataLayer.Repositories.QuestionDraftQuality_
{
    public class DraftQualityRepository : IDraftQualityRepository
    {
        private readonly IContributionDbContext _context;
        public DraftQualityRepository(IContributionDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(QuestionDraftQuality qu)
        {
            _context.QuestionDraftQualities.Add(qu);
            await _context.SaveChangesAsync();
            return qu.Id;
        }

        public async Task<bool> Delete(QuestionDraftQuality qu)
        {
            _context.QuestionDraftQualities.Remove(qu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<QuestionDraftQuality>> GetAll()
        {
           return await _context.QuestionDraftQualities.ToListAsync();
        }

        public async Task<QuestionDraftQuality> GetById(int id)
        {
            return await _context.QuestionDraftQualities.FindAsync(id);
        }

        public async Task<List<QuestionDraftQuality>> GetByQuestion(int questionId)
        {
            return await _context.QuestionDraftQualities.Where(q=>q.QuestionDraftId==questionId).ToListAsync();
        }

        public async Task<List<QuestionDraftQuality>> GetByUser(int userId)
        {
            return await _context.QuestionDraftQualities.Where(q => q.CreatedBy == userId).ToListAsync();
        }

        public async Task<bool> Update(QuestionDraftQuality qu)
        {
            _context.QuestionDraftQualities.Update(qu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
