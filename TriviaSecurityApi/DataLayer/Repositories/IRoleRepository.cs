using TriviaSecurityApi.DataLayer.Entities;

namespace TriviaSecurityApi.DataLayer.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAll();
        Task<Role> GetRoleById(int id);
        Task<Role> GetRoleByName(string name);
        Task<int> UpdateRole(Role user);
        Task<int> AddRole(Role user);
    }
}
