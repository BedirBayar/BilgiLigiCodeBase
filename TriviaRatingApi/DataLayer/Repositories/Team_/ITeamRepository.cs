using TriviaRatingApi.DataLayer.Entities;

namespace TriviaRatingApi.DataLayer.Repositories.Team_
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAll();
        Task<List<Team>> GetByRank(int min, int max);
        Task<Team> GetById(int id);
        Task<Team> GetByName(string name);
        Task<bool> Update(Team team);
        Task<int> Add(Team team);
        
    }
}
