using TriviaRatingApi.DataLayer.Entities;

namespace TriviaRatingApi.DataLayer.Repositories.Rank_
{
    public interface IRankRepository
    {
        Task<List<Rank>> GetAll();
        Task<List<Rank>> GetAllUser();
        Task<List<Rank>> GetAllTeam();
        Task<Rank> GetById(int id);
        Task<Rank> GetByName(string name);
        Task<List<Rank>> GetByDegree(int degree);
        Task<int> Add(Rank rank);
        Task<bool> Update(Rank rank);
        
    }
}
