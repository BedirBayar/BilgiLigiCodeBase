using Microsoft.EntityFrameworkCore;
using BilgiLigiContestApi.DataAccess.Entities;
using BilgiLigiContestApi.DataAccess.Repositories.Contest_;

namespace BilgiLigiContestApi.DataAccess.Repositories.ContestType_
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

        public async Task<List<ContestType>> GetAll() => await _context.ContestTypes.IgnoreQueryFilters().ToListAsync();
        public async Task<List<ContestType>> GetAllActive() => await _context.ContestTypes.Where(t=>t.IsActive).ToListAsync();

        public async Task<ContestType> GetById(int id) => await _context.ContestTypes.FindAsync(id);
        public async Task<ContestType> GetByName(string name) => await _context.ContestTypes.FirstOrDefaultAsync(t=>t.Name.ToLower()==name.ToLower());

        public async Task<bool> Update(ContestType ctype)
        {
            _context.ContestTypes.Update(ctype);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}
