using TriviaContributionApi.DataLayer.Entities;
using TriviaContributionApi.DataLayer.Relationships;

namespace TriviaContributionApi.DataLayer.Repositories.QuestionDraftQuality_
{
    public interface IDraftQualityRepository
    {
        Task<List<QuestionDraftQuality>> GetAll();
        Task<List<QuestionDraftQuality>> GetByQuestion(int questionId);
        Task<List<QuestionDraftQuality>> GetByUser(int userId);
        Task<QuestionDraftQuality> GetById(int id);
        Task<int> Add(QuestionDraftQuality qu);
        Task<bool> Update(QuestionDraftQuality qu);
        Task<bool> Delete(QuestionDraftQuality qu);
    }
}
