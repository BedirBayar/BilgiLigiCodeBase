using BilgiLigiContestApi.DataAccess.Relationships;

namespace BilgiLigiContestApi.DataAccess.Repositories.LeaderBoardUser_
{
    public interface ILeaderBoardUserRepository
    {
        Task<List<LeaderBoardUser>> GetAll();
        Task<LeaderBoardUser> GetById(int id);
        Task<int> Add(LeaderBoardUser team);
        Task<bool> AddRange(List<LeaderBoardUser> teams);
        Task<bool> Update(LeaderBoardUser team);

    }
}
