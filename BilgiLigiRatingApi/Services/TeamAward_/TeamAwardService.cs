using AutoMapper;
using BilgiLigiRatingApi.DataLayer.Repositories.TeamAward_;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Models.TeamModels;
using BilgiLigiRatingApi.DataLayer.Relationships;
using Azure.Core;

namespace BilgiLigiRatingApi.Services.TeamAward_
{
    public class TeamAwardService : BaseService, ITeamAwardService
    {
        private readonly ITeamAwardRepository _repository;
       public TeamAwardService (ITeamAwardRepository repository, IMapper _mapper) : base(_mapper)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<bool>> Add(AddTeamAwardRequest request)
        {
            try
            {
                var exist = await _repository.GetByTeamAndAward(request.TeamId, request.AwardId);
                if (exist != null) return new BaseResponse<bool>(Get400("Bu takım zaten bu ödüle sahip."));
                var entity = new TeamAward { TeamId = request.TeamId, AwardId = request.AwardId };
                var result = await _repository.Add(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Delete(AddTeamAwardRequest request)
        {
            try
            {
                var exist = await _repository.GetByTeamAndAward(request.TeamId, request.AwardId);
                if (exist == null) return new BaseResponse<bool>(Get404());
                var result = await _repository.Delete(exist);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<TeamAwardDto>>> GetTeamAwards(int teamId)
        {
            try
            {
                var data = await _repository.GetByTeam(teamId);
                if (data == null) return new BaseResponse<List<TeamAwardDto>>(Get404());
                var list= _mapper.Map<List<TeamAwardDto>>(data);
                return new BaseResponse<List<TeamAwardDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TeamAwardDto>>(Get500(ex.Message));
            }
        }
    }
}
