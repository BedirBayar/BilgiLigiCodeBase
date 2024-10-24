using AutoMapper;
using System.Collections.Generic;
using BilgiLigiContestApi.DataAccess.Entities;
using BilgiLigiContestApi.DataLayer.Repositories.ContestRule_;
using BilgiLigiContestApi.DTOs;

namespace BilgiLigiContestApi.Services.ContestRule_
{
    public class ContestRuleService : BaseService, IContestRuleService
    {
        private readonly IContestRuleRepository _repository;
        public ContestRuleService(IContestRuleRepository repository, IMapper _mapper, AuthenticatedUserService _aus) : base(_mapper, _aus)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<int>> Add(ContestRuleDto rule)
        {
            try
            {
                var exist = await _repository.GetByContestTypeAndOrder(rule.ContestTypeId, rule.Order);
                if (exist != null)  return new BaseResponse<int>(Get400("Aynı sırada bir kural mevcut"));
                ContestRule entity = _mapper.Map<ContestRule>(rule);
                entity.CreatedBy = _aus.UserId;
                entity.CreatedOn = DateTime.Now;
                var id= await _repository.Add(entity);
                return new BaseResponse<int>(id);
            }
            catch (Exception ex) {
                return new BaseResponse<int> (Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Archive(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.ArchivedOn = DateTime.Now;
                entity.ArchivedBy = _aus.UserId;
                entity.IsArchived = true;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool> (true);
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
                entity.UpdatedOn = DateTime.Now;
                entity.UpdatedBy = _aus.UserId;
                entity.IsActive = !entity.IsActive;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<ContestRuleDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<ContestRuleDto>>(Get404());
                var list = _mapper.Map<List<ContestRuleDto>>(data);
                return new BaseResponse<List<ContestRuleDto>> (list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestRuleDto>> ( Get500(ex.Message) );
            }
        }
        public async Task<BaseResponse<List<ContestRuleDto>>> GetAllActive()
        {
            try
            {
                var data = await _repository.GetAllActive();
                if (data == null) return new BaseResponse<List<ContestRuleDto>>(Get404());
                var list = _mapper.Map<List<ContestRuleDto>>(data);
                return new BaseResponse<List<ContestRuleDto>> (list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestRuleDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<ContestRuleDto>>> GetByContestType(int cTypeId)
        {
            try
            {
                var data = await _repository.GetByContestType(cTypeId);
                if (data == null) return new BaseResponse<List<ContestRuleDto>>(Get404());
                var list = _mapper.Map<List<ContestRuleDto>>(data);
                return new BaseResponse<List<ContestRuleDto>> (list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestRuleDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<ContestRuleDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data == null) return new BaseResponse<ContestRuleDto>(Get404());
                var item = _mapper.Map<ContestRuleDto>(data);
                return new BaseResponse<ContestRuleDto>(item);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContestRuleDto>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Update(ContestRuleDto rule)
        {
            try
            {
                var entity = await _repository.GetById(rule.Id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.UpdatedOn = DateTime.Now;
                entity.UpdatedBy = -_aus.UserId;
                entity.Description = rule.Description;
                entity.Order = rule.Order;
                entity.IsActive = rule.IsActive;
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
