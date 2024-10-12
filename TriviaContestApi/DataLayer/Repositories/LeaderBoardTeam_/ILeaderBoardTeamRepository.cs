using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataAccess.Repositories.LeaderBoardTeam_
{
    public interface ILeaderBoardTeamRepository
    {
        Task<List<LeaderBoardTeam>> GetAll();
        Task<LeaderBoardTeam> GetById(int id);
        Task<int> Add(LeaderBoardTeam team);
        Task<bool> AddRange(List<LeaderBoardTeam> teams);
        Task<bool> Update(LeaderBoardTeam team);

    }
}
