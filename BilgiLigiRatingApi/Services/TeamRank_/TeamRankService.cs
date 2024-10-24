using AutoMapper;
using BilgiLigiRatingApi.DataLayer.Entities;
using BilgiLigiRatingApi.DataLayer.Repositories.TeamRank_;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;

namespace BilgiLigiRatingApi.Services.TeamRank_
{
    public class TeamRankService : BaseService, ITeamRankService
    {
        private readonly ITeamRankRepository _repository;
        public TeamRankService(IMapper mapper, ITeamRankRepository repository, AuthenticatedUserService _aus) : base(mapper, _aus)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<TeamRankDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<TeamRankDto>>(Get404());
                var list = _mapper.Map<List<TeamRankDto>>(data);
                return new BaseResponse<List<TeamRankDto>>(list);
            }
            catch (Exception ex) {
                return new BaseResponse<List<TeamRankDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<TeamRankDto>> GetTeamRank(int teamId)
        {
            try
            {
                var data = await _repository.GetByTeam(teamId);
                if (data == null) return new BaseResponse<TeamRankDto>(Get404());
                var list = _mapper.Map<TeamRankDto>(data);
                return new BaseResponse<TeamRankDto>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TeamRankDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Update(TeamRankDto teamRankDto)
        {
            try
            {
                var data = await _repository.GetByTeam(teamRankDto.TeamId);
                if (data == null) return new BaseResponse<bool>(Get404());
                data.RankDegree = teamRankDto.RankDegree;
                var result= await _repository.Update(data);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(TeamRankDto teamRankDto)
        {
            try
            {
                var data = await _repository.GetByTeam(teamRankDto.TeamId);
                if (data != null) return new BaseResponse<int>(Get400("Bu takıma ait bir rütbe mevcut"));
                var entity=new TeamRankDto { RankDegree = teamRankDto.RankDegree , TeamId=teamRankDto.TeamId};
                var result = await _repository.Add(data);
                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Delete(int teamId)
        {
            try
            {
                var data = await _repository.GetByTeam(teamId);
                if (data == null) return new BaseResponse<bool>(Get404());
                var result = await _repository.Delete(data);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
