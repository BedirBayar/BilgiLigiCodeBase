using BilgiLigiRatingApi.DataLayer.Relationships;

namespace BilgiLigiRatingApi.DataLayer.Repositories.TeamAward_
{
    public interface ITeamAwardRepository
    {
        Task<int> Add(TeamAward tr);
        Task<List<TeamAward>> GetAll();
        Task<List<TeamAward>> GetByAward(int awardId);
        Task<List<TeamAward>> GetByTeam(int id);
        Task<TeamAward> GetByTeamAndAward(int teamId,int awardId);
        Task<bool> Update(TeamAward tr);
        Task<bool> Delete(TeamAward tr);
    }
}
