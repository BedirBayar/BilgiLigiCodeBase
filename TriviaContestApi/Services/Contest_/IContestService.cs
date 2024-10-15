
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.Contest_
{
    public interface IContestService
    {
        Task<BaseResponse<List<ContestDto>>> GetAll();
        Task<BaseResponse<ContestDto>> GetById(int id);
        Task<BaseResponse<ContestDto>> GetByName(string name);
        Task<BaseResponse<int>> Add(ContestDto cat);
        Task<BaseResponse<bool>> Update(ContestDto cat);
        Task<BaseResponse<bool>> Archive(int id);
        Task<BaseResponse<bool>> ChangeStatus(int id);
    }
}
