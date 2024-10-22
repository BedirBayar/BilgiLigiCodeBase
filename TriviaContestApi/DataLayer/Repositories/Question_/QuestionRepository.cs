using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Question_
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly IContestDbContext _context;
        public QuestionRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Question qu)
        {
            _context.Questions.Add(qu);
            await _context.SaveChangesAsync();
            return qu.Id;
        }
        public async Task<List<int>> AddRange(List<Question> qus)
        {
            _context.Questions.AddRange(qus);
            await _context.SaveChangesAsync();
            return qus.Select(q=>q.Id).ToList();
        }

        public async Task<List<Question>> GetAll() => await _context.Questions.IgnoreQueryFilters().ToListAsync();
        public async Task<List<Question>> GetAllActive() => await _context.Questions.Where(q=>q.IsActive).ToListAsync();
        public async Task<List<Question>> GetByCategory(int categoryId) => await _context.Questions.Where(q=>q.CategoryId==categoryId && q.IsActive).ToListAsync();
        public async Task<List<Question>> GetByDifficulty(int easy, int hard) => await _context.Questions.Where(q=>q.Difficulty>=easy &&q.Difficulty<= hard && q.IsActive).ToListAsync();

        public async Task<Question> GetById(int id) => await _context.Questions.IgnoreQueryFilters().SingleOrDefaultAsync(q=>q.Id==id);
        public async Task<List<Question>> GetByIdList(List<int> ids) => await _context.Questions.IgnoreQueryFilters().Where(m=>ids.Contains(m.Id)).ToListAsync();

        public async Task<bool> Update(Question qu)
        {
            _context.Questions.Update(qu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
