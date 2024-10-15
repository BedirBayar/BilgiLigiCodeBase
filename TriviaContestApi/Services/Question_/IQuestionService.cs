using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.Question_
{
    public interface IQuestionService
    {
        Task<BaseResponse<List<QuestionDto>>> GetAll();
        Task<BaseResponse<List<QuestionDto>>> GetByCategory(int categoryId);
        Task<BaseResponse<List<QuestionDto>>> GetByDifficulty(int easy, int hard);
        Task<BaseResponse<QuestionDto>> GetById(int id);
        Task<BaseResponse<int>> Add (QuestionDto question);
        Task<BaseResponse<List<int>>> AddRange (List<QuestionDto> questions);
        Task<BaseResponse<bool>> Update(QuestionDto question);
        Task<BaseResponse<bool>> ChangeStatus(QuestionDto question);
        Task<BaseResponse<bool>> Archive(QuestionDto question);
    }
}
