using TriviaContributionApi.DataLayer.Entities;

namespace TriviaContributionApi.DataLayer.Repositories.QuestionDraft_
{
    public interface IQuestionDraftRepository
    {
        Task<List<QuestionDraft>> GetAll();
        Task<List<QuestionDraft>> GetByCategory(int categoryId);
        Task<List<QuestionDraft>> GetByIdList(List<int> id);
        Task<List<QuestionDraft>> GetByContributor(int userId);
        Task<QuestionDraft> GetById(int id);
        Task<int> Add(QuestionDraft qu);
        Task<bool> Update(QuestionDraft qu);
        Task<bool> Delete(QuestionDraft qu);
    }
}
