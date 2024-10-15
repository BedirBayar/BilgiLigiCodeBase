using AutoMapper;
using TriviaContestApi.DataAccess.Repositories.LeaderBoard_;
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.LeaderBoard_
{
    public class LeaderBoardService :BaseService, ILeaderBoardService
    {
        private readonly ILeaderBoardRepository _repository;
        public LeaderBoardService(ILeaderBoardRepository repository,IMapper _mapper) : base(_mapper)
        {
            _repository = repository;
        }

       
        public async Task<BaseResponse<LeaderBoardDto>> GetById(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity != null)
                {
                    var dto = _mapper.Map<LeaderBoardDto>(entity);
                    return new BaseResponse<LeaderBoardDto> { Data = dto, Success = true };
                }
                return new BaseResponse<LeaderBoardDto> { Success = false, Error = Get404() };
            }
            catch (Exception ex) {

                return new BaseResponse<LeaderBoardDto> { Success = false, Error = Get500(ex.Message) };
            }
        }
        public async Task<BaseResponse<List<LeaderBoardDto>>> GetAllIncomplete()
        {
            try
            {
                var data = await _repository.GetAllIncomplete();
                if (data != null)
                {
                    var dto = _mapper.Map<List<LeaderBoardDto>>(data);
                    return new BaseResponse<List<LeaderBoardDto>> { Data = dto, Success = true };
                }
                return new BaseResponse<List<LeaderBoardDto>> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {

                return new BaseResponse<List<LeaderBoardDto>> { Success = false, Error = Get500(ex.Message) };
            }
        }
        public async Task<BaseResponse<List<LeaderBoardDto>>> GetAllComplete(DateTime startDate, DateTime endDate)
        {
            try
            {
                var data = await _repository.GetAllComplete(startDate,endDate);
                if (data != null)
                {
                    var dto = _mapper.Map<List<LeaderBoardDto>>(data);
                    return new BaseResponse<List<LeaderBoardDto>> { Data = dto, Success = true };
                }
                return new BaseResponse<List<LeaderBoardDto>> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {

                return new BaseResponse<List<LeaderBoardDto>> { Success = false, Error = Get500(ex.Message) };
            }
        }
        public async Task<BaseResponse<bool>> Update(LeaderBoardDto leaderBoardDto)
        {
            try
            {
                var entity = await _repository.GetById(leaderBoardDto.Id);
                if (entity != null)
                {
                    entity.Name = leaderBoardDto.Name;
                    entity.Notes = leaderBoardDto.Notes;
                    entity.UpdatedOn = DateTime.Now;
                    bool result=await _repository.Update(entity);
                    return new BaseResponse<bool> { Data = result, Success = true };
                }
                return new BaseResponse<bool> { Success = false, Error = Get404() };
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool> { Success = false, Error = Get500(ex.Message) };
            }
        }
    }
}
