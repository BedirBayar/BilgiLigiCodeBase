using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserTeam_
{
    public interface IUserTeamRepository
    {
        Task<List<UserTeam>> GetAll();
        Task<List<UserTeam>> GetByTeam(int id);
        Task<List<UserTeam>> GetByUser(int id);
        Task<UserTeam> GetByUserAndTeam(int userId, int teamId);
        Task<int> Add(UserTeam tr);
        Task<bool> Delete(UserTeam tr);
        Task<bool> DeleteTeam(List<UserTeam> tr);
        
    }
}
