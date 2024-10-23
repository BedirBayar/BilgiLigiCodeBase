
using BilgiLigiContestApi.DTOs;
using BilgiLigiContestApi.Models.ContestModels;

namespace BilgiLigiContestApi.Services.Contest_
{
    public interface IContestService
    {
        Task<BaseResponse<List<ContestDto>>> GetAll();
        Task<BaseResponse<List<ContestDto>>> GetAllUnfinished();
        Task<BaseResponse<ContestDto>> GetById(int id);
        Task<BaseResponse<ContestDto>> GetByName(string name);
        Task<BaseResponse<int>> Add(ContestDto cat);
        Task<BaseResponse<bool>> Update(ContestDto cat);
        Task<BaseResponse<bool>> Start(int id);
        Task<BaseResponse<bool>> End(int id);
        Task<BaseResponse<bool>> Archive(int id);
        Task<BaseResponse<bool>> ChangeStatus(int id);
        Task<BaseResponse<bool>> RegisterUser(RegisterUserToContestRequest request);
        Task<BaseResponse<bool>> RegisterTeam(RegisterTeamToContestRequest request);
        Task<BaseResponse<bool>> WithdrawUser(RegisterUserToContestRequest request);
        Task<BaseResponse<bool>> WithdrawTeam(RegisterTeamToContestRequest request);
    }
}
