using AutoMapper;
using Azure.Core;
using System.Collections.Generic;
using BilgiLigiRatingApi.DataLayer.Relationships;
using BilgiLigiRatingApi.DataLayer.Repositories.UserRank_;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Models.UserModels;

namespace BilgiLigiRatingApi.Services.UserRank_
{
    public class UserRankService : BaseService, IUserRankService
    {
        private readonly IUserRankRepository _repository;
        public UserRankService(IMapper _mapper, IUserRankRepository repository) : base(_mapper)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<int>> Add(AddUserRankRequest request)
        {
            try
            {
                //1. implementasyon
                var exist = await _repository.GetByUser(request.UserId);
                if (exist != null) return new BaseResponse<int>(Get400("Bu kulanıcının zaten rütbesi mevcut"));
                var entity = new UserRank { UserId = request.UserId, RankDegree = request.RankDegree };
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

        public async Task<BaseResponse<List<UserRankDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<UserRankDto>>(Get404());
                var list = _mapper.Map<List<UserRankDto>>(data);
                return new BaseResponse<List<UserRankDto>>(list);

            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserRankDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<UserRankDto>>> GetByRank(int rank)
        {
            try
            {
                var data = await _repository.GetByRank(rank);
                if (data == null) return new BaseResponse<List<UserRankDto>>(Get404());
                var list = _mapper.Map<List<UserRankDto>>(data);
                return new BaseResponse<List<UserRankDto>>(list);

            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserRankDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<UserRankDto>> GetByUser(int id)
        {
            try
            {
                var data = await _repository.GetByUser(id);
                if (data == null) return new BaseResponse<UserRankDto>(Get404());
                var dto = _mapper.Map<UserRankDto>(data);
                return new BaseResponse<UserRankDto>(dto);

            }
            catch (Exception ex)
            {
                return new BaseResponse<UserRankDto>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Update(AddUserRankRequest request)
        {
            try
            {
                var exist = await _repository.GetByUser(request.UserId);
                if (exist == null) return new BaseResponse<bool>(Get404());
                exist.RankDegree=request.RankDegree;
                var result = await _repository.Update(exist);
                return new BaseResponse<bool>(result);

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
