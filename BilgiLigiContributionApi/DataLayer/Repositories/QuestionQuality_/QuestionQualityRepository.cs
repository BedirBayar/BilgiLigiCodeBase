using Microsoft.EntityFrameworkCore;
using BilgiLigiContributionApi.DataLayer.Relationships;

namespace BilgiLigiContributionApi.DataLayer.Repositories.QuestionQuality_
{
    public class QuestionQualityRepository : IQuestionQualityRepository
    {
        private readonly IContributionDbContext _context;
        public QuestionQualityRepository(IContributionDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(QuestionQuality qu)
        {
            _context.QuestionQualities.Add(qu);
            await _context.SaveChangesAsync();
            return qu.Id;
        }

        public async Task<bool> Delete(QuestionQuality qu)
        {
            _context.QuestionQualities.Remove(qu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<QuestionQuality>> GetAll()
        {
           return await _context.QuestionQualities.ToListAsync();
        }

        public async Task<QuestionQuality> GetById(int id)
        {
            return await _context.QuestionQualities.FindAsync(id);
        }

        public async Task<List<QuestionQuality>> GetByQuestion(int questionId)
        {
            return await _context.QuestionQualities.Where(q=>q.QuestionId==questionId).ToListAsync();
        }

        public async Task<List<QuestionQuality>> GetByUser(int userId)
        {
            return await _context.QuestionQualities.Where(q => q.CreatedBy == userId).ToListAsync();
        }
        public async Task<QuestionQuality> GetByUserAndQuestion(int userId,int questionId)
        {
            return await _context.QuestionQualities.SingleOrDefaultAsync(q => q.CreatedBy == userId && q.QuestionId==questionId);
        }

        public async Task<bool> Update(QuestionQuality qu)
        {
            _context.QuestionQualities.Update(qu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
