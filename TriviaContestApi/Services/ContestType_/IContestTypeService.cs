using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.ContestType_
{
    public interface IContestTypeService
    {
        Task<BaseResponse<List<ContestTypeDto>>> GetAll();
        Task<BaseResponse<ContestTypeDto>> GetById(int id);
        Task<BaseResponse<ContestTypeDto>> GetByName(string name);
        Task<BaseResponse<int>> Add(ContestTypeDto type);
        Task<BaseResponse<bool>> Update(ContestTypeDto type);
        Task<BaseResponse<bool>> Archive(int id);
        Task<BaseResponse<bool>> ChangeStatus(int id);
    }
}
