using Microsoft.EntityFrameworkCore;
using BilgiLigiContributionApi.DataLayer.Entities;

namespace BilgiLigiContributionApi.DataLayer.Repositories.QuestionDraft_
{
    public class QuestionDraftRepository : IQuestionDraftRepository
    {
        private readonly IContributionDbContext _context;
        public QuestionDraftRepository(IContributionDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(QuestionDraft qu)
        {
           _context.QuestionDrafts.Add(qu);
            await _context.SaveChangesAsync();
            return qu.Id;
        }

        public async Task<bool> Delete(QuestionDraft qu)
        {
            _context.QuestionDrafts.Remove(qu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<QuestionDraft>> GetAll()
        {
            return await _context.QuestionDrafts.ToListAsync();
        }

        public async Task<List<QuestionDraft>> GetByCategory(int categoryId)
        {
            return await _context.QuestionDrafts.Where(d=>d.CategoryId==categoryId).ToListAsync();
        }
        
        public async Task<List<QuestionDraft>> GetByContributor(int userId)
        {
            return await _context.QuestionDrafts.Where(d=>d.CreatedBy==userId).ToListAsync();
        }

        public async Task<QuestionDraft> GetById(int id)
        {
            return await _context.QuestionDrafts.FindAsync(id);
        }

        public async Task<List<QuestionDraft>> GetByIdList(List<int> ids)
        {
            return await _context.QuestionDrafts.Where(d=>ids.Contains(d.Id)).ToListAsync();
        }

        public async Task<bool> Update(QuestionDraft qu)
        {
            _context.QuestionDrafts.Update(qu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
