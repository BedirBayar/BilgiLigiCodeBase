using AutoMapper;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DataAccess.Repositories.ContestType_;
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.ContestType_
{
    public class ContestTypeService : BaseService, IContestTypeService
    {
        private readonly IContestTypeRepository _repository;
        public ContestTypeService(IContestTypeRepository repository, IMapper _mapper) : base(_mapper) { 
            _repository = repository;
        }
        public async Task<BaseResponse<int>> Add(ContestTypeDto type)
        {
            try
            {
                var exist = await _repository.GetByName(type.Name);
                if (exist != null)
                {
                    ContestType entity = _mapper.Map<ContestType>(type);
                    var id = await _repository.Add(entity);
                    return new BaseResponse<int> { Success = true, Data = id };
                }
                return new BaseResponse<int> { Success = false, Data = -1, Error = Get400("Aynı isimde bir yarışma tipi mevcut") };
            }
            catch (Exception ex)
            {
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

        public async Task<BaseResponse<List<ContestTypeDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data != null)
                {
                    var list = _mapper.Map<List<ContestTypeDto>>(data);
                    return new BaseResponse<List<ContestTypeDto>> { Data = list, Success = true };
                }
                return new BaseResponse<List<ContestTypeDto>> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestTypeDto>> { Success = false, Error = Get500(ex.Message) };
            }
        }
        public async Task<BaseResponse<List<ContestTypeDto>>> GetAllActive()
        {
            try
            {
                var data = await _repository.GetAllActive();
                if (data != null)
                {
                    var list = _mapper.Map<List<ContestTypeDto>>(data);
                    return new BaseResponse<List<ContestTypeDto>> { Data = list, Success = true };
                }
                return new BaseResponse<List<ContestTypeDto>> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ContestTypeDto>> { Success = false, Error = Get500(ex.Message) };
            }
        }
        
        public async Task<BaseResponse<ContestTypeDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data != null)
                {
                    var item = _mapper.Map<ContestTypeDto>(data);
                    return new BaseResponse<ContestTypeDto> { Data = item, Success = true };
                }
                return new BaseResponse<ContestTypeDto> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContestTypeDto> { Success = false, Error = Get500(ex.Message) };
            }
        }
        public async Task<BaseResponse<ContestTypeDto>> GetByName(string name)
        {
            try
            {
                var data = await _repository.GetByName(name);
                if (data != null)
                {
                    var item = _mapper.Map<ContestTypeDto>(data);
                    return new BaseResponse<ContestTypeDto> { Data = item, Success = true };
                }
                return new BaseResponse<ContestTypeDto> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ContestTypeDto> { Success = false, Error = Get500(ex.Message) };
            }
        }

        public async Task<BaseResponse<bool>> Update(ContestTypeDto type)
        {
            try
            {
                var entity = await _repository.GetById(type.Id);
                if (entity != null)
                {
                    if (entity.Name == type.Name)
                        return new BaseResponse<bool> { Success = false, Data = false, Error = Get400("Aynı isimde başka bir yarışma tipi mevcut") };
                    entity.UpdatedOn = DateTime.Now;
                    entity.Description = type.Description;
                    entity.IsActive = type.IsActive;
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
