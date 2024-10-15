using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.Match_
{
    public interface IUserMatchService
    {
        Task<BaseResponse<List<UserMatchDto>>> GetAll();
        Task<BaseResponse<List<UserMatchDto>>> GetByContest(int contestId);
        Task<BaseResponse<List<UserMatchDto>>> GetByUser(int userId);
        Task<BaseResponse<UserMatchDto>> GetById(int id);
    }
}
