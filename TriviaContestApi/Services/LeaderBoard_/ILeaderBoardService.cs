using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.LeaderBoard_
{
    public interface ILeaderBoardService
    {
        Task<BaseResponse<LeaderBoardDto>> GetById(int id);
        Task<BaseResponse<List<LeaderBoardDto>>> GetAllIncomplete();
        Task<BaseResponse<List<LeaderBoardDto>>> GetAllComplete(DateTime startDate, DateTime endDate);
        Task<BaseResponse<bool>> Update(LeaderBoardDto leaderBoardDto);
    }
}
