using AutoMapper;
using BilgiLigiContributionApi.DataLayer.Relationships;
using BilgiLigiContributionApi.DataLayer.Repositories.UserContributionRating_;
using BilgiLigiContributionApi.DTOs;

namespace BilgiLigiContributionApi.Services
{
    public class UserContributionRatingService : BaseService
    {
        private readonly IUserContributionRatingRepository _repository;
        public UserContributionRatingService(IUserContributionRatingRepository repository,IMapper _mapper, AuthenticatedUserService _aus):base(_mapper, _aus)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<List<UserContributionRatingDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<UserContributionRatingDto>>(Get404());
                var list = _mapper.Map<List<UserContributionRatingDto>>(data);
                return new BaseResponse<List<UserContributionRatingDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserContributionRatingDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<UserContributionRatingDto>>> GetTopN(int n)
        {
            try
            {
                var data = await _repository.GetTopN(n);
                if (data == null) return new BaseResponse<List<UserContributionRatingDto>>(Get404());
                var list = _mapper.Map<List<UserContributionRatingDto>>(data);
                return new BaseResponse<List<UserContributionRatingDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserContributionRatingDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<UserContributionRatingDto>>> GetByRatingInterval(int min, int max)
        {
            try
            {
                var data = await _repository.GetByRatingInterval(min,max);
                if (data == null) return new BaseResponse<List<UserContributionRatingDto>>(Get404());
                var list = _mapper.Map<List<UserContributionRatingDto>>(data);
                return new BaseResponse<List<UserContributionRatingDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserContributionRatingDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<UserContributionRatingDto>> GetByUser(int userId)
        {
            try
            {
                var data = await _repository.GetByUser(userId);
                if (data == null) return new BaseResponse<UserContributionRatingDto>(Get404());
                var list = _mapper.Map<UserContributionRatingDto>(data);
                return new BaseResponse<UserContributionRatingDto>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserContributionRatingDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(UserContributionRatingDto request)
        {
            try
            {
                var data = await _repository.GetByUser(request.UserId);
                if (data != null) return new BaseResponse<int>(Get400("Bu kullanıcıya ait bir katkı puanı zaten mevcut"));
                var entity = new UserContributionRating
                {
                    UserId = request.UserId,
                    ContributionRating = request.ContributionRating
                };
                var id = await _repository.Add(entity);
                return new BaseResponse<int>(id);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Update(UserContributionRatingDto request)
        {
            try
            {
                var data = await _repository.GetByUser(request.UserId);
                if (data == null) return new BaseResponse<bool>(Get404());

                data.ContributionRating = request.ContributionRating;
                var result = await _repository.Update(data);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Delete(int id)
        {
            try
            {
                var data = await _repository.GetByUser(id);
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
