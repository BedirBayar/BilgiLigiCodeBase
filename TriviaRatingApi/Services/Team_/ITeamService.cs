using TriviaRatingApi.DataLayer.Entities;
using TriviaRatingApi.DTOs;
using TriviaRatingApi.Models;

namespace TriviaRatingApi.Services.Team_
{
    public interface ITeamService
    {
        Task<BaseResponse<List<TeamDto>>> GetAll();
        Task<BaseResponse<List<TeamDto>>> GetAllActive();
        Task<BaseResponse<TeamDto>> GetById(int id);
        Task<BaseResponse<TeamDto>> GetByName(string name);
        Task<BaseResponse<TeamDto>> GetByRank(int min, int max);
        Task<BaseResponse<int>> Add(TeamDto dto);
        Task<BaseResponse<bool>> Update(TeamDto dto);
        Task<BaseResponse<bool>> Archive(int id);
        Task<BaseResponse<bool>> ChangeStatus(int id);
        Task<BaseResponse<bool>> BanUnban(BanRequest request);
    }
}
