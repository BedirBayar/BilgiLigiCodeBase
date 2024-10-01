using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataAccess.Repositories.MatchQuestion_
{
    public interface IMatchQuestionRepository
    {
        Task<List<MatchQuestion>> GetAll();
        Task<MatchQuestion> GetById(int id);
        Task<int> Add(MatchQuestion mq);
        Task<bool> AddRange(List<MatchQuestion> mq);
        Task<bool> Update(MatchQuestion mq);

    }
}
