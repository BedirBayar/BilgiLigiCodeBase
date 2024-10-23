using BilgiLigiContestApi.DataAccess.Relationships;

namespace BilgiLigiContestApi.DataAccess.Repositories.MatchQuestion_
{
    public interface ITeamMatchQuestionRepository
    {
        Task<List<TeamMatchQuestion>> GetAll();
        Task<TeamMatchQuestion> GetById(int id);
        Task<int> Add(TeamMatchQuestion mq);
        Task<bool> AddRange(List<TeamMatchQuestion> mq);
        Task<bool> Update(TeamMatchQuestion mq);

    }
}
