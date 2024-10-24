using AutoMapper;
using BilgiLigiContestApi.DataAccess.Entities;
using BilgiLigiContestApi.DataAccess.Repositories.ContestType_;
using BilgiLigiContestApi.DTOs;

namespace BilgiLigiContestApi.Services.ContestType_
{
    public class ContestTypeService : BaseService, IContestTypeService
    {
        private readonly IContestTypeRepository _repository;
        public ContestTypeService(IContestTypeRepository repository, IMapper _mapper, AuthenticatedUserService _aus) : base(_mapper, _aus) { 
            _repository = repository;
        }
        public async Task<BaseResponse<int>> Add(ContestTypeDto type)
        {
            try
            {
                var exist = await _repository.GetByName(type.Name);
                if (exist != null) return new BaseResponse<int>(Get400("Aynı isimde bir yarışma tipi mevcut"));
                ContestType entity = _mapper.Map<ContestType>(type);
                entity.CreatedBy=_aus.UserId;
                entity.CreatedOn=DateTime.Now;
                var id = await _repository.Add(entity);
                return new BaseResponse<int> (id);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int> (Get500(ex.Message) );
            }
        }

        public async Task<BaseResponse<bool>> Archive(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.ArchivedOn = DateTime.Now;
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
                return new BaseResponse<bool> (true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<ContestTypeDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<ContestTypeDto>>(Get404());
                var list = _mapper.Map<List<ContestTypeDto>>(data);
                return new BaseResponse<List<ContestTypeDto>> (list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestTypeDto>>(Get500(ex.Message) );
            }
        }
        public async Task<BaseResponse<List<ContestTypeDto>>> GetAllActive()
        {
            try
            {
                var data = await _repository.GetAllActive();
                if (data == null) return new BaseResponse<List<ContestTypeDto>>(Get404());
                var list = _mapper.Map<List<ContestTypeDto>>(data);
                return new BaseResponse<List<ContestTypeDto>> (list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestTypeDto>>(Get500(ex.Message));
            }
        }
        
        public async Task<BaseResponse<ContestTypeDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data == null) return new BaseResponse<ContestTypeDto>(Get404());
                var item = _mapper.Map<ContestTypeDto>(data);
                return new BaseResponse<ContestTypeDto>(item);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContestTypeDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<ContestTypeDto>> GetByName(string name)
        {
            try
            {
                var data = await _repository.GetByName(name);
                if (data == null) return new BaseResponse<ContestTypeDto>(Get404());
                var item = _mapper.Map<ContestTypeDto>(data);
                return new BaseResponse<ContestTypeDto> (item);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContestTypeDto>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Update(ContestTypeDto type)
        {
            try
            {
                var entity = await _repository.GetById(type.Id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                if (entity.Name == type.Name)
                return new BaseResponse<bool> (Get400("Aynı isimde başka bir yarışma tipi mevcut") );
                entity.UpdatedOn = DateTime.Now;
                entity.UpdatedBy = _aus.UserId;
                entity.Description = type.Description;
                entity.IsActive = type.IsActive;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool> (true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
