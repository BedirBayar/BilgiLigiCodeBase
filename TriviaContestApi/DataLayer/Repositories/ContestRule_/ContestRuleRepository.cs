using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess;
using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataLayer.Repositories.ContestRule_
{
    public class ContestRuleRepository : IContestRuleRepository
    {
        private readonly IContestDbContext _context;

        public ContestRuleRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ContestRule contestRule)
        {
            _context.ContestRules.Add(contestRule);
            await _context.SaveChangesAsync();
            return contestRule.Id;
        }

        public async Task<List<ContestRule>> GetAll()
        {
            return await _context.ContestRules.ToListAsync();
        }
        public async Task<List<ContestRule>> GetAllActive()
        {
            return await _context.ContestRules.Where(r=>r.IsActive).ToListAsync();
        }

        public async Task<List<ContestRule>> GetByContestType(int cTypeId)
        {
            return await _context.ContestRules.Where(r => r.ContestTypeId == cTypeId).ToListAsync();
        }
        
        public async Task<List<ContestRule>> GetByContestTypeAndOrder(int cTypeId, int order)
        {
            return await _context.ContestRules.Where(r => r.ContestTypeId == cTypeId && r.Order==order).ToListAsync();
        }

        public async Task<ContestRule> GetById(int id)
        {
            return await _context.ContestRules.FindAsync(id);
        }

        public async Task<bool> Update(ContestRule contestRule)
        {
            _context.ContestRules.Update(contestRule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
