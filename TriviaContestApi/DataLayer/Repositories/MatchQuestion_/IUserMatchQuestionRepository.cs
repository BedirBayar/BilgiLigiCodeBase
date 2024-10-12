using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataAccess.Repositories.MatchQuestion_
{
    public interface IUserMatchQuestionRepository
    {
        Task<List<UserMatchQuestion>> GetAll();
        Task<UserMatchQuestion> GetById(int id);
        Task<int> Add(UserMatchQuestion mq);
        Task<bool> AddRange(List<UserMatchQuestion> mq);
        Task<bool> Update(UserMatchQuestion mq);

    }
}
