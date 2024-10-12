using TriviaContestApi.DataAccess.Entities;

namespace TriviaContestApi.DataAccess.Repositories.Question_
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAll();
        Task<Question> GetById(int id);
        Task<List<Question>> GetByIdList(List<int> ids);
        Task<bool> Update(Question qu);
        Task<int> Add(Question qu);
    }
}
