using TriviaContributionApi.DataLayer.Entities;
using TriviaContributionApi.DataLayer.Relationships;

namespace TriviaContributionApi.DataLayer.Repositories.QuestionQuality_
{
    public interface IQuestionQualityRepository
    {
        Task<List<QuestionQuality>> GetAll();
        Task<List<QuestionQuality>> GetByQuestion(int questionId);
        Task<List<QuestionQuality>> GetByUser(int userId);
        Task<QuestionQuality> GetByUserAndQuestion(int userId,int questionId);
        Task<QuestionQuality> GetById(int id);
        Task<int> Add(QuestionQuality qu);
        Task<bool> Update(QuestionQuality qu);
        Task<bool> Delete(QuestionQuality qu);
    }
}
