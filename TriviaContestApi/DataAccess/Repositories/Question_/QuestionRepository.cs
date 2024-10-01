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

        public async Task<List<Question>> GetAll() => await _context.Questions.ToListAsync();

        public async Task<Question> GetById(int id) => await _context.Questions.FindAsync(id);
        public async Task<List<Question>> GetByIdList(List<int> ids) => await _context.Questions.Where(m=>ids.Contains(m.Id)).ToListAsync();

        public async Task<bool> Update(Question qu)
        {
            _context.Questions.Update(qu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
