using AutoMapper;
using System.Collections.Generic;
using BilgiLigiRatingApi.DataLayer.Relationships;
using BilgiLigiRatingApi.DataLayer.Repositories.UserAward_;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Models.UserModels;

namespace BilgiLigiRatingApi.Services.UserAward_
{
    public class UserAwardService : BaseService, IUserAwardService
    {
        private readonly IUserAwardRepository _repository;

        public UserAwardService(IMapper mapper, IUserAwardRepository repository, AuthenticatedUserService _aus) : base(mapper, _aus)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<int>> Add(AddUserAwardRequest request)
        {
            try
            {
                var exist = await _repository.GetByUserAndAward(request.UserId, request.AwardId);
                if (exist != null) return new BaseResponse<int>(Get400("Kullanıcı zaten bu ödüle sahip"));
                var entity = new UserAward { UserId = request.UserId, AwardId = request.AwardId };
                var result = await _repository.Add(entity);
                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Delete(AddUserAwardRequest request)
        {
            try
            {
                var exist = await _repository.GetByUserAndAward(request.UserId, request.AwardId);
                if (exist == null) return new BaseResponse<bool>(Get404("Kullanıcı zaten bu ödüle sahip"));
                var result = await _repository.Delete(exist);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<UserAwardDto>>> GetUserAwards(int userId)
        {
            try
            {
                var data = await _repository.GetByUser(userId);
                if (data == null) return new BaseResponse<List<UserAwardDto>>(Get404());
                var list = _mapper.Map<List<UserAwardDto>>(data);
                return new BaseResponse<List<UserAwardDto>>(list);
            }
            catch (Exception ex) 
            {
                return new BaseResponse<List<UserAwardDto>>(Get500(ex.Message));
            }
        }
    }
}
