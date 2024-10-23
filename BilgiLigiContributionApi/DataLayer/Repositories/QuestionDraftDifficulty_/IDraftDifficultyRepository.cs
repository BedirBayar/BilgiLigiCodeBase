using BilgiLigiContributionApi.DataLayer.Entities;
using BilgiLigiContributionApi.DataLayer.Relationships;

namespace BilgiLigiContributionApi.DataLayer.Repositories.QuestionDraftDifficulty_
{
    public interface IDraftDifficultyRepository
    {
        Task<List<QuestionDraftDifficulty>> GetAll();
        Task<List<QuestionDraftDifficulty>> GetByQuestion(int questionId);
        Task<List<QuestionDraftDifficulty>> GetByUser(int userId);
        Task<QuestionDraftDifficulty> GetById(int id);
        Task<QuestionDraftDifficulty> GetByUserAndQuestion(int userId, int questionId);
        Task<int> Add(QuestionDraftDifficulty qu);
        Task<bool> Update(QuestionDraftDifficulty qu);
        Task<bool> Delete(QuestionDraftDifficulty qu);
    }
}
