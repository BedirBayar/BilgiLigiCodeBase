using Microsoft.EntityFrameworkCore;
using TriviaSecurityApi.DataLayer.Entities;

namespace TriviaSecurityApi.DataLayer.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private readonly ISecurityDbContext _context;
        public RoleRepository(ISecurityDbContext context ) { 
            _context = context;
        }

        public async Task<int> AddRole(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return role.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<List<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r=>r.Id==id);
        }
        public async Task<Role> GetRoleByName(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(r=>r.Name==name);
        }

        public async Task<int> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            return await _context.SaveChangesAsync();
         }
    }
}
