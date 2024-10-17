using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer.Repositories.UserTeam_
{
    public interface IUserTeamRepository
    {
        Task<List<UserTeam>> GetAll();
        Task<List<UserTeam>> GetByTeam(int id);
        Task<List<UserTeam>> GetByUser(int id);
        Task<bool> Update(UserTeam tr);
        Task<int> Add(UserTeam tr);
        Task<bool> Delete(UserTeam tr);
        
    }
}
