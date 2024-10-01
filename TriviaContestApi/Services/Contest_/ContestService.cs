using AutoMapper;
using TriciaContestApi.DTOs;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DataAccess.Repositories.Contest_;
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.Contest_
{
    public class ContestService : IContestService
    {
        private readonly IContestRepository _contestRep;
        private readonly IMapper _mapper;
        public ContestService(IContestRepository contestRep, IMapper mapper)
        {
            _contestRep = contestRep;
            _mapper = mapper;
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
                        Error = new ErrorResponse
                        {
                            Code = "500",
                            Message = ex.Message,
                        }
                    };
                }
            }
            return new BaseResponse<int>
            {
                Data = -1,
                Success = false,
                Error = new ErrorResponse
                {
                    Code = "400",
                    Message = "Aynı isimde bir kategori mevcut",
                }
            };
        }

        public Task<BaseResponse<bool>> Archive(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> ChangeStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<List<ContestDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<ContestDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<ContestDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> Update(ContestDto cat)
        {
            throw new NotImplementedException();
        }
    }
}
