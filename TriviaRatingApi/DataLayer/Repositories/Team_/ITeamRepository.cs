using TriviaRatingApi.DataLayer.Entities;

namespace TriviaRatingApi.DataLayer.Repositories.Team_
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAll();
        Task<List<Team>> GetByRank(int rank);
        Task<Team> GetById(int id);
        Task<Team> GetByName(int name);
        Task<bool> Update(Team team);
        Task<int> Add(Team team);
        
    }
}
