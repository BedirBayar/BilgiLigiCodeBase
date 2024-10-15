using AutoMapper;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DataAccess.Repositories.Contest_;
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.Contest_
{
    public class ContestService : BaseService, IContestService
    {
        private readonly IContestRepository _contestRep;
        public ContestService(IContestRepository contestRep, IMapper _mapper) : base(_mapper)
        {
            _contestRep = contestRep;
        }
        public async Task<BaseResponse<int>> Add(ContestDto cont)
        {
            var exist = await _contestRep.GetByName(cont.Name);
            if (exist == null)
            {
                var entity = new Contest
                {
                    Name = cont.Name,
                    Description = cont.Description,
                    IsActive = cont.IsActive,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now
                };
                try
                {
                    int result = await _contestRep.Add(entity);
                    return new BaseResponse<int>(result);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<int>
                    {
                        Data = -1,
                        Success = false,
                        Error = Get500(ex.Message)
                    };
                }
            }
            return new BaseResponse<int>
            {
                Data = -1,
                Success = false,
                Error = Get400("Aynı isimde bir yarışma mevcut")
            };
        }

        public async Task<BaseResponse<bool>> Archive(int id)
        {
            try
            {
                var entity = await _contestRep.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.IsArchived = true;
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

        public async Task<BaseResponse<ContestDto>> GetById(int id)
        {
            try
            {
                var data = await _contestRep.GetById(id);
                if (data == null) return new BaseResponse<ContestDto>(Get404());
                var dto = _mapper.Map<ContestDto>(data);
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
                var result = await _contestRep.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
