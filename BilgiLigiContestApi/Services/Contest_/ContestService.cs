using AutoMapper;
using System.Collections.Generic;
using BilgiLigiContestApi.DataAccess.Entities;
using BilgiLigiContestApi.DataAccess.Relationships;
using BilgiLigiContestApi.DataAccess.Repositories.Contest_;
using BilgiLigiContestApi.DataAccess.Repositories.ContestAward_;
using BilgiLigiContestApi.DataLayer.Relationships;
using BilgiLigiContestApi.DataLayer.Repositories.ContestTeam_;
using BilgiLigiContestApi.DataLayer.Repositories.ContestUser_;
using BilgiLigiContestApi.DTOs;
using BilgiLigiContestApi.Models.ContestModels;

namespace BilgiLigiContestApi.Services.Contest_
{
    public class ContestService : BaseService, IContestService
    {
        private readonly IContestRepository _contestRep;
        private readonly IContestAwardRepository _contestAwardRep;
        private readonly IContestUserRepository _contestUserRep;
        private readonly IContestTeamRepository _contestTeamRep;
        public ContestService(
            IContestRepository contestRep,
            IContestAwardRepository car, 
            IContestUserRepository contestUserRep,
            IContestTeamRepository contestTeamRep,
            IMapper _mapper, AuthenticatedUserService _aus) 
            : base(_mapper, _aus)
        {
            _contestRep = contestRep;
            _contestUserRep = contestUserRep;
            _contestTeamRep = contestTeamRep;
            _contestAwardRep = car;
        }
        public async Task<BaseResponse<int>> Add(ContestDto cont)
        {
            try
            {
                var exist = await _contestRep.GetByName(cont.Name);
                if (exist != null) return new BaseResponse<int>(Get400("Aynı isimde bir yarışma mevcut"));
            
                var entity = new Contest
                {
                    Name = cont.Name,
                    Description = cont.Description,
                    IsActive = cont.IsActive,
                    CreatedBy = _aus.UserId,
                    CreatedOn = DateTime.Now
                };
                int result = await _contestRep.Add(entity);
                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int> (Get500(ex.Message));
            }
           
        }
        public async Task<BaseResponse<bool>> Archive(int id)
        {
            try
            {
                var entity = await _contestRep.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.IsArchived = true;
                entity.ArchivedBy = _aus.UserId;
                entity.ArchivedOn = DateTime.Now;
                var result = await _contestRep.Update(entity);
                return new BaseResponse<bool>(result);
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
                var entity = await _contestRep.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.IsActive = !entity.IsActive;
                entity.UpdatedBy = _aus.UserId;
                entity.UpdatedOn = DateTime.Now;
                var result = await _contestRep.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Start(int id)
        {
            try
            {
                var entity = await _contestRep.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.IsRunning = true;
                entity.UpdatedBy = _aus.UserId;
                entity.UpdatedOn = DateTime.Now;
                var result = await _contestRep.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> End(int id)
        {
            try
            {
                var entity = await _contestRep.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.IsRunning = false;
                entity.UpdatedBy = _aus.UserId;
                entity.UpdatedOn = DateTime.Now;
                var result = await _contestRep.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<ContestDto>>> GetAll()
        {
            try
            {
                var data = await _contestRep.GetAll();
                if (data == null || data.Count == 0) return new BaseResponse<List<ContestDto>>(Get404());
                var list = _mapper.Map<List<ContestDto>>(data);
                return new BaseResponse<List<ContestDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<ContestDto>>> GetAllUnfinished()
        {
            try
            {
                var data = await _contestRep.GetAllUnfinished();
                if (data == null || data.Count == 0) return new BaseResponse<List<ContestDto>>(Get404());
                var list = _mapper.Map<List<ContestDto>>(data);
                foreach (var item in list)
                {
                    var awards= await _contestAwardRep.GetByContest(item.Id);
                    item.Awards= _mapper.Map<List<ContestAwardDto>>(awards);
                }
                return new BaseResponse<List<ContestDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<ContestDto>> GetById(int id)
        {
            try
            {
                var data = await _contestRep.GetById(id);
                if (data == null) return new BaseResponse<ContestDto>(Get404());
                var dto = _mapper.Map<ContestDto>(data);
                var award = await _contestAwardRep.GetByContest(dto.Id);
                dto.Awards = _mapper.Map<List<ContestAwardDto>>(award);
                return new BaseResponse<ContestDto>(dto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContestDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<ContestDto>> GetByName(string name)
        {
            try
            {
                var data = await _contestRep.GetByName(name);
                if (data == null) return new BaseResponse<ContestDto>(Get404());
                var dto = _mapper.Map<ContestDto>(data);
                var award = await _contestAwardRep.GetByContest(dto.Id);
                dto.Awards = _mapper.Map<List<ContestAwardDto>>(award);
                return new BaseResponse<ContestDto>(dto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContestDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Update(ContestDto contest)
        {

            try
            {
                var entity = await _contestRep.GetById(contest.Id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.Name= contest.Name;
                entity.Description= contest.Description;
                entity.StartDate= contest.StartDate;
                entity.EndDate= contest.EndDate;
                entity.IsPeriodic = contest.IsPeriodic;
                entity.ContestantNumber = contest.ContestantNumber;
                entity.PeriodType = contest.PeriodType;
                entity.MinimumRank = contest.MinimumRank;
                entity.MaximumRank = contest.MaximumRank;
                entity.MatchFrequency = contest.MatchFrequency;

                entity.UpdatedBy = _aus.UserId;
                entity.UpdatedOn = DateTime.Now;
                var result = await _contestRep.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> RegisterUser(RegisterUserToContestRequest request)
        {
            try
            {
                var user = await _contestUserRep.GetByUserAndContest(request.UserId, request.ContestId);
                if (user != null) return new BaseResponse<bool>(true);
                var entity = new ContestUser { ContestId = request.ContestId, UserId = request.UserId };
                var result = await _contestUserRep.Add(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> RegisterTeam(RegisterTeamToContestRequest request)
        {
            try
            {
                var user = await _contestTeamRep.GetByTeamAndContest(request.TeamId, request.ContestId);
                if (user != null) return new BaseResponse<bool>(true);
                var entity = new ContestTeam { ContestId = request.ContestId, TeamId = request.TeamId };
                var result = await _contestTeamRep.Add(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> WithdrawUser(RegisterUserToContestRequest request)
        {
            try
            {
                var user = await _contestUserRep.GetByUserAndContest(request.UserId, request.ContestId);
                if (user != null)
                {
                    var result = await _contestUserRep.Delete(user);
                    return new BaseResponse<bool>(true);
                }
                return new BaseResponse<bool>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> WithdrawTeam(RegisterTeamToContestRequest request)
        {
            try
            {
                var team = await _contestTeamRep.GetByTeamAndContest(request.TeamId, request.ContestId);
                if (team != null)
                {
                    var result = await _contestTeamRep.Delete(team);
                    return new BaseResponse<bool>(true);
                }
                return new BaseResponse<bool>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
