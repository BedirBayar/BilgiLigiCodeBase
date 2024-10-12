using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DataAccess.Repositories.Contest_;

namespace TriviaContestApi.DataAccess.Repositories.ContestType_
{
    public class ContestTypeRepository :IContestTypeRepository
    {
        private readonly IContestDbContext _context;
        public ContestTypeRepository(IContestDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ContestType ctype)
        {
            _context.ContestTypes.Add(ctype);
            await _context.SaveChangesAsync();
            return ctype.Id;
        }

        public async Task<List<ContestType>> GetAll() => await _context.ContestTypes.ToListAsync();

        public async Task<ContestType> GetById(int id) => await _context.ContestTypes.FindAsync(id);

        public async Task<bool> Update(ContestType ctype)
        {
            _context.ContestTypes.Update(ctype);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}
