using AutoMapper;
using Azure.Core;
using BilgiLigiRatingApi.DataLayer.Entities;
using BilgiLigiRatingApi.DataLayer.Relationships;
using BilgiLigiRatingApi.DataLayer.Repositories.UserTeam_;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;

namespace BilgiLigiRatingApi.Services.UserTeam_
{
    public class UserTeamService : BaseService, IUserTeamService
    {
        private readonly IUserTeamRepository _repository;
        public UserTeamService(IMapper _mapper, IUserTeamRepository repository) : base(_mapper)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<int>> AddUserToTeam(UserTeamDto request)
        {
            try
            {
                var exist = await _repository.GetByUserAndTeam(request.UserId, request.TeamId);
                if (exist != null) return new BaseResponse<int>(Get400("Kullanıcı zaten belirtilen takımın üyesi"));
                var entity = new UserTeam { TeamId = request.TeamId, UserId = request.UserId };
                var result = await _repository.Add(entity);
                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> DissolveTeam(int teamId)
        {
            try
            {
                var data = await _repository.GetByTeam(teamId);
                if (data == null) return new BaseResponse<bool>(Get404());
                var result = await _repository.DeleteTeam(data);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<UserTeamDto>>> GetTeamUsers(int teamId)
        {
            try
            {
                var data = await _repository.GetByTeam(teamId);
                if (data == null) return new BaseResponse<List<UserTeamDto>>(Get404());
                var list= _mapper.Map<List<UserTeamDto>>(data);
                return new BaseResponse<List<UserTeamDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserTeamDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<UserTeamDto>>> GetUserTeams(int userId)
        {
            try
            {
                var data = await _repository.GetByUser(userId);
                if (data == null) return new BaseResponse<List<UserTeamDto>>(Get404());
                var list = _mapper.Map<List<UserTeamDto>>(data);
                return new BaseResponse<List<UserTeamDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserTeamDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> RemoveUserFromTeam(UserTeamDto request)
        {
            try
            {
                var exist = await _repository.GetByUserAndTeam(request.UserId, request.TeamId);
                if (exist == null) return new BaseResponse<bool>(Get404());
                var entity = new UserTeam { TeamId = request.TeamId, UserId = request.UserId };
                var result = await _repository.Delete(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
