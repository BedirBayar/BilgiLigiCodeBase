using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.TeamAward_
{
    public interface ITeamAwardRepository
    {
        Task<int> Add(TeamAward tr);
        Task<List<TeamAward>> GetAll();
        Task<List<TeamAward>> GetByAward(int awardId);
        Task<TeamAward> GetByTeam(int id);
        Task<bool> Update(TeamAward tr);
    }
}
