using BilgiLigiContributionApi.DataLayer.Entities;
using BilgiLigiContributionApi.DataLayer.Relationships;

namespace BilgiLigiContributionApi.DataLayer.Repositories.QuestionDraftQuality_
{
    public interface IDraftQualityRepository
    {
        Task<List<QuestionDraftQuality>> GetAll();
        Task<List<QuestionDraftQuality>> GetByQuestion(int draftId);
        Task<List<QuestionDraftQuality>> GetByUser(int userId);
        Task<QuestionDraftQuality> GetByUserAndQuestion(int userId,int questionId);
        Task<QuestionDraftQuality> GetById(int id);
        Task<int> Add(QuestionDraftQuality qu);
        Task<bool> Update(QuestionDraftQuality qu);
        Task<bool> Delete(QuestionDraftQuality qu);
    }
}
