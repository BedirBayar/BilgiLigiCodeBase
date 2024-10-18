using AutoMapper;
using TriviaRatingApi.DataLayer.Relationships;
using TriviaRatingApi.DataLayer.Repositories.TeamRating_;
using TriviaRatingApi.DTOs;
using TriviaRatingApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TriviaRatingApi.Services.TeamRating_
{
    public class TeamRatingService : BaseService, ITeamRatingService
    {
        private readonly ITeamRatingRepository _repository;
        public TeamRatingService(IMapper _mapper, ITeamRatingRepository repository) : base(_mapper)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<int>> Add(TeamRatingDto teamRatingDto)
        {
            try
            {
                var exist = await _repository.GetByTeam(teamRatingDto.TeamId);
                if (exist != null) return new BaseResponse<int>(Get400("Bu takım zaten bir reytinge sahip"));
                var entity= new TeamRating { TeamId = teamRatingDto.TeamId , Rating= teamRatingDto.Rating};
                var result = await _repository.Add(entity);
                
                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Delete(int id)
        {
            try
            {
                var exist = await _repository.GetByTeam(id);
                if (exist == null) return new BaseResponse<bool>(Get404());
                var result = await _repository.Delete(exist);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<TeamRatingDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<TeamRatingDto>>(Get404());
                var list = _mapper.Map<List<TeamRatingDto>>(data);
                return new BaseResponse<List<TeamRatingDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TeamRatingDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<TeamRatingDto>>> GetByRatingInterval(int min, int max)
        {
            try
            {
                var data = await _repository.GetByRatingInterval(min, max);
                if (data == null) return new BaseResponse<List<TeamRatingDto>>(Get404());
                var list = _mapper.Map<List<TeamRatingDto>>(data);
                return new BaseResponse<List<TeamRatingDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TeamRatingDto>>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<TeamRatingDto>> GetByTeam(int teamId)
        {
            try
            {
                var data = await _repository.GetByTeam(teamId);
                if (data == null) return new BaseResponse<TeamRatingDto>(Get404());
                var dto = _mapper.Map<TeamRatingDto>(data);
                return new BaseResponse<TeamRatingDto>(dto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TeamRatingDto>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Update(TeamRatingDto teamRatingDto)
        {
            try
            {
                var data = await _repository.GetByTeam(teamRatingDto.TeamId);
                if (data == null) return new BaseResponse<bool>(Get404());
                data.Rating = teamRatingDto.Rating;
                var result = await _repository.Update(data);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
