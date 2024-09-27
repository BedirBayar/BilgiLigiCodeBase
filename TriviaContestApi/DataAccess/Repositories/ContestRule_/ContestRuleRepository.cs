using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.ContestRule_
{
    public class ContestRuleRepository :IContestRuleRepository
    {
        private readonly IContestDbContext _context;
        public ContestRuleRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ContestRule rule)
        {
            _context.ContestRules.Add(rule);
            await _context.SaveChangesAsync();
            return rule.Id;
        }

        public async Task<List<ContestRule>> GetAll() => await _context.ContestRules.ToListAsync();

        public async Task<ContestRule> GetById(int id) => await _context.ContestRules.FindAsync(id);

        public async Task<bool> Update(ContestRule rule)
        {
            _context.ContestRules.Update(rule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
