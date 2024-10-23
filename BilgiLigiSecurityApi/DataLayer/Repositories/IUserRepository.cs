using BilgiLigiSecurityApi.DataLayer.Entities;

namespace BilgiLigiSecurityApi.DataLayer.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByUsername(string username);
        Task<bool> UpdateUser(User user);
        Task<int> AddUser (User user);
    }
}
