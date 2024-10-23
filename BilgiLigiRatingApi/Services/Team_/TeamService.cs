using AutoMapper;
using System.Collections.Generic;
using BilgiLigiRatingApi.DataLayer.Entities;
using BilgiLigiRatingApi.DataLayer.Repositories.Team_;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Models.TeamModels;

namespace BilgiLigiRatingApi.Services.Team_
{
    public class TeamService : BaseService, ITeamService
    {
        private readonly ITeamRepository _repository;
        public TeamService(IMapper _mapper, ITeamRepository repository) : base(_mapper)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<List<TeamDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<TeamDto>>(data);
                    return new BaseResponse<List<TeamDto>>(list);
                }
                return new BaseResponse<List<TeamDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TeamDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<TeamDto>>> GetAllActive()
        {
            try
            {
                var data = await _repository.GetAllActive();
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<TeamDto>>(data);
                    return new BaseResponse<List<TeamDto>>(list);
                }
                return new BaseResponse<List<TeamDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TeamDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<TeamDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data != null)
                {
                    var list = _mapper.Map<TeamDto>(data);
                    return new BaseResponse<TeamDto>(list);
                }
                return new BaseResponse<TeamDto>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<TeamDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<TeamDto>> GetByName(string name)
        {
            try
            {
                var data = await _repository.GetByName(name);
                if (data != null)
                {
                    var list = _mapper.Map<TeamDto>(data);
                    return new BaseResponse<TeamDto>(list);
                }
                return new BaseResponse<TeamDto>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<TeamDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<TeamDto>> GetByRank(int min, int max)
        {
            try
            {
                var data = await _repository.GetByRank(min,max);
                if (data != null)
                {
                    var list = _mapper.Map<TeamDto>(data);
                    return new BaseResponse<TeamDto>(list);
                }
                return new BaseResponse<TeamDto>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<TeamDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(TeamDto dto)
        {
            try
            {
                var entity = _mapper.Map<Team>(dto);
                entity.IsActive = true;
                entity.CreatedOn = DateTime.Now;
                var id = await _repository.Add(entity);
                if (id>0)
                {
                    return new BaseResponse<int>(id);
                }
                return new BaseResponse<int>(Get400());
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Update(TeamDto dto)
        {
            try
            {
                var entity = await _repository.GetById(dto.Id);
                entity.Name = dto.Name;
                entity.Slogan=dto.Slogan;
                entity.Image= dto.Image;
                entity.UpdatedOn = DateTime.Now;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(result);
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
                entity.IsArchived = true;
                entity.ArchivedOn = DateTime.Now;
                entity.UpdatedOn = DateTime.Now;
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
                entity.IsActive = !entity.IsActive;
                entity.UpdatedOn = DateTime.Now;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> BanUnban(BanRequest request)
        {
            try
            {
                var entity = await _repository.GetById(request.BannedId);
                if (request.UnbanRequest)
                {
                    entity.IsBanned = false;
                }
                else
                {
                    entity.IsBanned = true;
                    entity.BannedUntil = DateTime.Now.AddDays(request.BanDays);
                    entity.BanReason = request.BanReason;
                }

                entity.UpdatedOn = DateTime.Now;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> ChangeLeader(ChangeLeaderRequest request)
        {
            try
            {
                var entity = await _repository.GetById(request.TeamId);
                entity.LeaderId = request.NewLeaderId;
                entity.UpdatedOn = DateTime.Now;
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
