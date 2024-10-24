using AutoMapper;
using BilgiLigiRatingApi.DataLayer.Entities;
using BilgiLigiRatingApi.DataLayer.Relationships;
using BilgiLigiRatingApi.DataLayer.Repositories.UserRating_;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;

namespace BilgiLigiRatingApi.Services.UserRating_
{
    public class UserRatingService : BaseService, IUserRatingService
    {
        private readonly IUserRatingRepository _repository;
        public UserRatingService(IMapper mapper, IUserRatingRepository repository, AuthenticatedUserService _aus) : base(mapper, _aus)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<int>> Add(UserRatingDto request)
        {
            try
            {
                var exist = await _repository.GetByUser(request.UserId);
                if (exist != null) return new BaseResponse<int>(Get400("Bu kullanıcı zaten bir reytinge sahip"));
                var entity = new UserRating { UserId = request.UserId, Rating = request.Rating };
                var result = await _repository.Add(entity);

                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Delete(int userId)
        {
            try
            {
                var exist = await _repository.GetByUser(userId);
                if (exist == null) return new BaseResponse<bool>(Get404());
                var result = await _repository.Delete(exist);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<UserRatingDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<UserRatingDto>>(Get404());
                var list = _mapper.Map<List<UserRatingDto>>(data);
                return new BaseResponse<List<UserRatingDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserRatingDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<UserRatingDto>>> GetByRatingInterval(int min, int max)
        {
            try
            {
                var data = await _repository.GetByRatingInterval(min, max);
                if (data == null) return new BaseResponse<List<UserRatingDto>>(Get404());
                var list = _mapper.Map<List<UserRatingDto>>(data);
                return new BaseResponse<List<UserRatingDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserRatingDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<UserRatingDto>> GetByUser(int id)
        {
            try
            {
                var data = await _repository.GetByUser(id);
                if (data == null) return new BaseResponse<UserRatingDto>(Get404());
                var dto = _mapper.Map<UserRatingDto>(data);
                return new BaseResponse<UserRatingDto>(dto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserRatingDto>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Update(UserRatingDto request)
        {
            try
            {
                var data = await _repository.GetByUser(request.UserId);
                if (data == null) return new BaseResponse<bool>(Get404());
                data.Rating = request.Rating;
                var result = await _repository.Update(data);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
