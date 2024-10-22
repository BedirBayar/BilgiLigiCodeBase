using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Category_
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<List<Category>> GetAllActive();
        Task<Category> GetById(int id);
        Task<Category> GetByName(string name);
        Task<bool> Update(Category cat);
        Task<int> Add(Category cat);

    }
}
