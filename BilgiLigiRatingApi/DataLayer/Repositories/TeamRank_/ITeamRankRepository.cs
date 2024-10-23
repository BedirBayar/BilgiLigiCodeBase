using BilgiLigiRatingApi.DataLayer.Relationships;

namespace BilgiLigiRatingApi.DataLayer.Repositories.TeamRank_
{
    public interface ITeamRankRepository
    {
        Task<List<TeamRank>> GetAll();
        Task<List<TeamRank>> GetByRank(int rank);
        Task<TeamRank> GetByTeam(int id);
        Task<bool> Update(TeamRank tr);
        Task<bool> Delete(TeamRank tr);
        Task<int> Add(TeamRank tr);
    }
}
