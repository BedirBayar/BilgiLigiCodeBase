using BilgiLigiSecurityApi.DataLayer.Entities;

namespace BilgiLigiSecurityApi.DataLayer.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAll();
        Task<Role> GetRoleById(int id);
        Task<Role> GetRoleByName(string name);
        Task<bool> UpdateRole(Role user);
        Task<int> AddRole(Role user);
    }
}
