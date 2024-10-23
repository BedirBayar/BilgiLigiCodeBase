using AutoMapper;
using BilgiLigiContestApi.DataAccess.Entities;
using BilgiLigiContestApi.DataAccess.Repositories.Match_;
using BilgiLigiContestApi.DTOs;

namespace BilgiLigiContestApi.Services.Match_
{
    public class UserMatchService :BaseService, IUserMatchService
    {
        private readonly IUserMatchRepository _repository;

        public UserMatchService(IUserMatchRepository repository, IMapper _mapper): base(_mapper)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<List<UserMatchDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<UserMatchDto>>(data);
                    return new BaseResponse<List<UserMatchDto>>(list);
                }
                return new BaseResponse<List<UserMatchDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserMatchDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<UserMatchDto>>> GetByContest(int contestId)
        {
            try
            {
                var data = await _repository.GetByContest(contestId);
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<UserMatchDto>>(data);
                    return new BaseResponse<List<UserMatchDto>>(list);
                }
                return new BaseResponse<List<UserMatchDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserMatchDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<UserMatchDto>>> GetByUser(int userId)
        {
            try
            {
                var data = await _repository.GetByUser(userId);
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<UserMatchDto>>(data);
                    return new BaseResponse<List<UserMatchDto>>(list);
                }
                return new BaseResponse<List<UserMatchDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserMatchDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<UserMatchDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data != null )
                {
                    var dto = _mapper.Map<UserMatchDto>(data);
                    return new BaseResponse<UserMatchDto>(dto);
                }
                return new BaseResponse<UserMatchDto>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserMatchDto>(Get500(ex.Message));
            }
        }
    }
}
