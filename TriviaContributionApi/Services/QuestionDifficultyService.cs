using AutoMapper;
using TriviaContributionApi.DataLayer.Relationships;
using TriviaContributionApi.DataLayer.Repositories.QuestionDifficulty_;
using TriviaContributionApi.DTOs;

namespace TriviaContributionApi.Services
{
    public class QuestionDifficultyService :BaseService
    {
        private readonly IQuestionDifficultyRepository _repository;
        public QuestionDifficultyService(IQuestionDifficultyRepository repository, IMapper _mapper) : base(_mapper)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<QuestionDifficultyDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<QuestionDifficultyDto>>(Get404());
                var list = _mapper.Map<List<QuestionDifficultyDto>>(data);
                return new BaseResponse<List<QuestionDifficultyDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDifficultyDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDifficultyDto>>> GetByQuestion(int draftId)
        {
            try
            {
                var data = await _repository.GetByQuestion(draftId);
                if (data == null) return new BaseResponse<List<QuestionDifficultyDto>>(Get404());
                var list = _mapper.Map<List<QuestionDifficultyDto>>(data);
                return new BaseResponse<List<QuestionDifficultyDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDifficultyDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDifficultyDto>>> GetByUser(int userId)
        {
            try
            {
                var data = await _repository.GetByUser(userId);
                if (data == null) return new BaseResponse<List<QuestionDifficultyDto>>(Get404());
                var list = _mapper.Map<List<QuestionDifficultyDto>>(data);
                return new BaseResponse<List<QuestionDifficultyDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDifficultyDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<QuestionDifficultyDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<QuestionDifficultyDto>(Get404());
                var dto = _mapper.Map<QuestionDifficultyDto>(data);
                return new BaseResponse<QuestionDifficultyDto>(dto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<QuestionDifficultyDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(QuestionDifficultyDto request)
        {
            try
            {
                var data = await _repository.GetByUserAndQuestion(request.CreatedBy, request.QuestionId);
                if (data != null) return new BaseResponse<int>(Get400("Bu soru için zorluk değerlendirmeniz zaten mevcut"));
                var entity = new QuestionDifficulty
                {
                    CreatedBy = request.CreatedBy,
                    QuestionId = request.QuestionId,
                    DifficultyPoint = request.DifficultyPoint,
                    CreatedOn = DateTime.Now
                };
                var id = await _repository.Add(entity);
                return new BaseResponse<int>(id);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Update(QuestionDifficultyDto request)
        {
            try
            {
                var data = await _repository.GetById(request.Id);
                if (data == null) return new BaseResponse<bool>(Get404());

                data.CreatedBy = request.CreatedBy;
                data.QuestionId = request.QuestionId;
                data.DifficultyPoint = request.DifficultyPoint;
                data.UpdatedOn = DateTime.Now;
                var id = await _repository.Update(data);
                return new BaseResponse<bool>(id);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Delete(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data == null) return new BaseResponse<bool>(Get404());
                var result = await _repository.Delete(data);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
