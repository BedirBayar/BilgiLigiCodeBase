using AutoMapper;
using TriviaRatingApi.DataLayer.Repositories.Award_;
using TriviaRatingApi.DTOs;
using TriviaRatingApi.Models;
using TriviaRatingApi.DataLayer.Entities;

namespace TriviaRatingApi.Services.Award_
{
    public class AwardService : BaseService, IAwardService
    {
        private readonly IAwardRepository _repository;
        public AwardService (IAwardRepository repository,IMapper _mapper) : base(_mapper) { 
            _repository = repository; 
        }
        public async Task<BaseResponse<int>> Add(AwardDto awardDto)
        {
            try
            {
                var exist = await _repository.GetByNameAndType(awardDto.Name, awardDto.UserOrTeam);
                if (exist == null)
                {
                    var entity = new Award()
                    {
                        Name = awardDto.Name,
                        Description = awardDto.Description,
                        UserOrTeam = awardDto.UserOrTeam,
                        Badge = awardDto.Badge,
                        CreatedOn = DateTime.Now,
                        IsActive = true
                    };
                    var id = await _repository.Add(entity);
                    return new BaseResponse<int>(id);

                }
                return new BaseResponse<int>(Get400("Aynı isimde bir ödül var"));
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Archive(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity != null)
                {
                    entity.IsArchived = true;
                    entity.ArchivedOn = DateTime.Now;
                    var result = await _repository.Update(entity);
                    return new BaseResponse<bool>(result);
                   
                }
                return new BaseResponse<bool>(Get404());
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
                if (entity != null)
                {
                    entity.IsActive = !entity.IsActive;
                    entity.UpdatedOn = DateTime.Now;
                    var result = await _repository.Update(entity);
                    return new BaseResponse<bool>(result);

                }
                return new BaseResponse<bool>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<AwardDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data != null && data.Count>0)
                {
                    var list= _mapper.Map<List<AwardDto>>(data);
                    return new BaseResponse<List<AwardDto>>(list);
                }
                return new BaseResponse<List<AwardDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<AwardDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<AwardDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data != null)
                {
                    var list = _mapper.Map<AwardDto>(data);
                    return new BaseResponse<AwardDto>(list);
                }
                return new BaseResponse<AwardDto>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<AwardDto>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<AwardDto>>> GetByIdList(List<int> ids)
        {
            try
            {
                var data = await _repository.GetAll();
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<AwardDto>>(data);
                    return new BaseResponse<List<AwardDto>>(list);
                }
                return new BaseResponse<List<AwardDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<AwardDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Update(AwardDto awardDto)
        {
            try
            {
                var entity = await _repository.GetById(awardDto.Id);
                if (entity != null)
                {
                    var exist = await _repository.GetByNameAndType(awardDto.Name,awardDto.UserOrTeam);
                    if(exist==null || exist.Id == awardDto.Id)
                    {
                        entity.Name = awardDto.Name;
                        entity.Description = awardDto.Description;
                        entity.Badge = awardDto.Badge;
                        entity.UpdatedOn= DateTime.Now;
                        var result = await _repository.Update(entity);
                        return new BaseResponse<bool>(result);
                    }
                    return new BaseResponse<bool>(Get400("Aynı isimde bir ödül var"));
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
