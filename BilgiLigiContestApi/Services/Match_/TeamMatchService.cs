using AutoMapper;
using BilgiLigiContestApi.DataAccess.Repositories.Match_;
using BilgiLigiContestApi.DTOs;

namespace BilgiLigiContestApi.Services.Match_
{
    public class TeamMatchService: BaseService, ITeamMatchService
    {
        private readonly ITeamMatchRepository _repository;
        public TeamMatchService(ITeamMatchRepository repository, IMapper _mapper, AuthenticatedUserService _aus):base(_mapper, _aus)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<TeamMatchDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<TeamMatchDto>>(data);
                    return new BaseResponse<List<TeamMatchDto>>(list);
                }
                return new BaseResponse<List<TeamMatchDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TeamMatchDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<TeamMatchDto>>> GetByContest(int contestId)
        {
            try
            {
                var data = await _repository.GetByContest(contestId);
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<TeamMatchDto>>(data);
                    return new BaseResponse<List<TeamMatchDto>>(list);
                }
                return new BaseResponse<List<TeamMatchDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TeamMatchDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<TeamMatchDto>>> GetByTeam(int teamId)
        {
            try
            {
                var data = await _repository.GetByTeam(teamId);
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<TeamMatchDto>>(data);
                    return new BaseResponse<List<TeamMatchDto>>(list);
                }
                return new BaseResponse<List<TeamMatchDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TeamMatchDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<TeamMatchDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data != null)
                {
                    var dto = _mapper.Map<TeamMatchDto>(data);
                    return new BaseResponse<TeamMatchDto>(dto);
                }
                return new BaseResponse<TeamMatchDto>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<TeamMatchDto>(Get500(ex.Message));
            }
        }
    }
}
