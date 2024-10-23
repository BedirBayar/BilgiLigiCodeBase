using BilgiLigiContestApi.DTOs;

namespace BilgiLigiContestApi.Services.Question_
{
    public interface IQuestionService
    {
        Task<BaseResponse<List<QuestionDto>>> GetAll();
        Task<BaseResponse<List<QuestionDto>>> GetAllActive();
        Task<BaseResponse<List<QuestionDto>>> GetByCategory(int categoryId);
        Task<BaseResponse<List<QuestionDto>>> GetByDifficulty(int easy, int hard);
        Task<BaseResponse<QuestionDto>> GetById(int id);
        Task<BaseResponse<int>> Add (QuestionDto question);
        Task<BaseResponse<List<int>>> AddRange (List<QuestionDto> questions);
        Task<BaseResponse<bool>> Update(QuestionDto question);
        Task<BaseResponse<bool>> ChangeStatus(int id);
        Task<BaseResponse<bool>> Archive(int id);
    }
}
