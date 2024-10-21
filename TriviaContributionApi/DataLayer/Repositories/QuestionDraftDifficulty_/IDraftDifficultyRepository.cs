using TriviaContributionApi.DataLayer.Entities;
using TriviaContributionApi.DataLayer.Relationships;

namespace TriviaContributionApi.DataLayer.Repositories.QuestionDraftDifficulty_
{
    public interface IDraftDifficultyRepository
    {
        Task<List<QuestionDraftDifficulty>> GetAll();
        Task<List<QuestionDraftDifficulty>> GetByQuestion(int questionId);
        Task<List<QuestionDraftDifficulty>> GetByUser(int userId);
        Task<QuestionDraftDifficulty> GetById(int id);
        Task<int> Add(QuestionDraftDifficulty qu);
        Task<bool> Update(QuestionDraftDifficulty qu);
        Task<bool> Delete(QuestionDraftDifficulty qu);
    }
}
