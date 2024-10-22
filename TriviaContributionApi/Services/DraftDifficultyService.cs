using AutoMapper;
using TriviaContributionApi.DataLayer.Relationships;
using TriviaContributionApi.DataLayer.Repositories.QuestionDraftDifficulty_;
using TriviaContributionApi.DTOs;

namespace TriviaContributionApi.Services
{
    public class DraftDifficultyService : BaseService
    {
        private readonly IDraftDifficultyRepository _repository;
        public DraftDifficultyService(IDraftDifficultyRepository repository, IMapper _mapper) : base(_mapper)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<QuestionDraftDifficultyDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<QuestionDraftDifficultyDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftDifficultyDto>>(data);
                return new BaseResponse<List<QuestionDraftDifficultyDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftDifficultyDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDraftDifficultyDto>>> GetByQuestion(int draftId)
        {
            try
            {
                var data = await _repository.GetByQuestion(draftId);
                if (data == null) return new BaseResponse<List<QuestionDraftDifficultyDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftDifficultyDto>>(data);
                return new BaseResponse<List<QuestionDraftDifficultyDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftDifficultyDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDraftDifficultyDto>>> GetByUser(int userId)
        {
            try
            {
                var data = await _repository.GetByUser(userId);
                if (data == null) return new BaseResponse<List<QuestionDraftDifficultyDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftDifficultyDto>>(data);
                return new BaseResponse<List<QuestionDraftDifficultyDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftDifficultyDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<QuestionDraftDifficultyDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<QuestionDraftDifficultyDto>(Get404());
                var dto = _mapper.Map<QuestionDraftDifficultyDto>(data);
                return new BaseResponse<QuestionDraftDifficultyDto>(dto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<QuestionDraftDifficultyDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(QuestionDraftDifficultyDto request)
        {
            try
            {
                var data = await _repository.GetByUserAndQuestion(request.CreatedBy, request.QuestionDraftId);
                if (data != null) return new BaseResponse<int>(Get400("Bu soru için zorluk değerlendirmeniz zaten mevcut"));
                var entity = new QuestionDraftDifficulty
                {
                    CreatedBy = request.CreatedBy,
                    QuestionDraftId = request.QuestionDraftId,
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
        public async Task<BaseResponse<bool>> Update(QuestionDraftDifficultyDto request)
        {
            try
            {
                var data = await _repository.GetById(request.Id);
                if (data == null) return new BaseResponse<bool>(Get404());

                data.CreatedBy = request.CreatedBy;
                data.QuestionDraftId = request.QuestionDraftId;
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
