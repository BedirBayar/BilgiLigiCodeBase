using AutoMapper;
using System.Collections.Generic;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DataLayer.Repositories.ContestRule_;
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.ContestRule_
{
    public class ContestRuleService : BaseService, IContestRuleService
    {
        private readonly IContestRuleRepository _repository;
        public ContestRuleService(IContestRuleRepository repository, IMapper _mapper) : base(_mapper)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<int>> Add(ContestRuleDto rule)
        {
            try
            {
                var exist = await _repository.GetByContestTypeAndOrder(rule.ContestTypeId, rule.Order);
                if (exist != null)
                {
                    ContestRule entity = _mapper.Map<ContestRule>(rule);
                   var id= await _repository.Add(entity);
                    return new BaseResponse<int> { Success=true,Data=id };
                }
                return new BaseResponse<int> { Success = false, Data = -1, Error = Get400("Aynı sırada bir kural mevcut") };
            }
            catch (Exception ex) {
                return new BaseResponse<int> { Success = false, Data = -1, Error = Get500(ex.Message) };
            }
        }

        public async Task<BaseResponse<bool>> Archive(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity != null)
                {
                    entity.ArchivedOn = DateTime.Now;
                    entity.IsArchived = true;
                    var result = await _repository.Update(entity);
                    return new BaseResponse<bool> { Success = true, Data = true };
                }
                return new BaseResponse<bool> { Success = false, Data = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Error = Get500(ex.Message)
                };
            }
        }

        public async Task<BaseResponse<bool>> ChangeStatus(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity != null)
                {
                    entity.UpdatedOn = DateTime.Now;
                    entity.IsActive = !entity.IsActive;
                    var result = await _repository.Update(entity);
                    return new BaseResponse<bool> { Success = true, Data = true };
                }
                return new BaseResponse<bool> { Success = false, Data = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Error = Get500(ex.Message)
                };
            }
        }

        public async Task<BaseResponse<List<ContestRuleDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data != null)
                {
                    var list = _mapper.Map<List<ContestRuleDto>>(data);
                    return new BaseResponse<List<ContestRuleDto>> { Data = list, Success = true };
                }
                return new BaseResponse<List<ContestRuleDto>> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestRuleDto>> { Success = false, Error = Get500(ex.Message) };
            }
        }
        public async Task<BaseResponse<List<ContestRuleDto>>> GetAllActive()
        {
            try
            {
                var data = await _repository.GetAllActive();
                if (data != null)
                {
                    var list = _mapper.Map<List<ContestRuleDto>>(data);
                    return new BaseResponse<List<ContestRuleDto>> { Data = list, Success = true };
                }
                return new BaseResponse<List<ContestRuleDto>> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestRuleDto>> { Success = false, Error = Get500(ex.Message) };
            }
        }

        public async Task<BaseResponse<List<ContestRuleDto>>> GetByContestType(int cTypeId)
        {
            try
            {
                var data = await _repository.GetByContestType(cTypeId);
                if (data != null)
                {
                    var list = _mapper.Map<List<ContestRuleDto>>(data);
                    return new BaseResponse<List<ContestRuleDto>> { Data = list, Success = true };
                }
                return new BaseResponse<List<ContestRuleDto>> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestRuleDto>> { Success = false, Error = Get500(ex.Message) };
            }
        }

        public async Task<BaseResponse<ContestRuleDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data != null)
                {
                    var item = _mapper.Map<ContestRuleDto>(data);
                    return new BaseResponse<ContestRuleDto> { Data = item, Success = true };
                }
                return new BaseResponse<ContestRuleDto> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContestRuleDto> { Success = false, Error = Get500(ex.Message) };
            }
        }

        public async Task<BaseResponse<bool>> Update(ContestRuleDto rule)
        {
            try
            {
                var entity = await _repository.GetById(rule.Id);
                if (entity != null)
                {
                    entity.UpdatedOn = DateTime.Now;
                    entity.Description = rule.Description;
                    entity.Order = rule.Order;
                    entity.IsActive = rule.IsActive;
                    var result = await _repository.Update(entity);
                    return new BaseResponse<bool> { Success = true, Data = true };
                }
                return new BaseResponse<bool> { Success = false, Data = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Error = Get500(ex.Message)
                };
            }
        }
    }
}
