using AutoMapper;
using System.Collections.Generic;
using BilgiLigiRatingApi.DataLayer.Repositories.Rank_;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;

namespace BilgiLigiRatingApi.Services.Rank_
{
    public class RankService: BaseService, IRankService
    {
        private readonly IRankRepository _repository;
        public RankService (IRankRepository repository, IMapper _mapper, AuthenticatedUserService _aus): base(_mapper, _aus)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<RankDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data != null)
                {
                    var list = _mapper.Map<List<RankDto>>(data);
                    return new BaseResponse<List<RankDto>>(list);
                }
                return new BaseResponse<List<RankDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<RankDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<RankDto>>> GetAllActive()
        {
            try
            {
                var data = await _repository.GetAllActive();
                if (data != null)
                {
                    var list = _mapper.Map<List<RankDto>>(data);
                    return new BaseResponse<List<RankDto>>(list);
                }
                return new BaseResponse<List<RankDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<RankDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<RankDto>>> GetUserRanks()
        {
            try
            {
                var data = await _repository.GetAllUser();
                if (data != null)
                {
                    var list = _mapper.Map<List<RankDto>>(data);
                    return new BaseResponse<List<RankDto>>(list);
                }
                return new BaseResponse<List<RankDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<RankDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<RankDto>>> GetTeamRanks()
        {
            try
            {
                var data = await _repository.GetAllTeam();
                if (data != null)
                {
                    var list = _mapper.Map<List<RankDto>>(data);
                    return new BaseResponse<List<RankDto>>(list);
                }
                return new BaseResponse<List<RankDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<RankDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<RankDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data != null)
                {
                    var list = _mapper.Map<RankDto>(data);
                    return new BaseResponse<RankDto>(list);
                }
                return new BaseResponse<RankDto>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<RankDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(RankDto rankDto)
        {
            try
            {
                var exist = await _repository.GetByDegreeAndType(rankDto.Degree, rankDto.UserOrTeam);
                if (exist != null) return new BaseResponse<int>(Get400("Aynı tip ve derecede başka bir rütbe var"));
                var entity = new DataLayer.Entities.Rank();
                entity.Name = rankDto.Name;
                entity.Degree = rankDto.Degree;
                entity.Description = rankDto.Description;
                entity.Insignia = rankDto.Insignia;
                entity.CreatedBy = _aus.UserId;
                entity.CreatedOn = DateTime.Now;
                entity.IsActive = true;
                var result = await _repository.Add(entity);
                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Update(RankDto rankDto)
        {
            try
            {
                var entity = await _repository.GetById(rankDto.Id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                var exist = await _repository.GetByDegreeAndType(rankDto.Degree, rankDto.UserOrTeam);
                if (exist != null && exist.Id!=entity.Id) return new BaseResponse<bool>(Get400("Aynı tip ve derecede başka bir rütbe var"));
                entity.Name = rankDto.Name;
                entity.Degree = rankDto.Degree;
                entity.Description = rankDto.Description;
                entity.Insignia = rankDto.Insignia;
                entity.UpdatedBy = _aus.UserId;
                entity.UpdatedOn = DateTime.Now;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Archive(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.IsArchived = true;
                entity.ArchivedOn = DateTime.Now;
                entity.ArchivedBy = _aus.UserId;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> ChangeStatus(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.IsActive = !entity.IsActive;
                entity.UpdatedOn = DateTime.Now;
                entity.UpdatedBy = _aus.UserId;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

    }
}
