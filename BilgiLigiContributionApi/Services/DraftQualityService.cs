using AutoMapper;
using BilgiLigiContributionApi.DataLayer.Relationships;
using BilgiLigiContributionApi.DataLayer.Repositories.QuestionDraftQuality_;
using BilgiLigiContributionApi.DTOs;

namespace BilgiLigiContributionApi.Services
{
    public class DraftQualityService :BaseService
    {
        private readonly IDraftQualityRepository _repository;
        public DraftQualityService(IDraftQualityRepository repository, IMapper _mapper) : base(_mapper)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<QuestionDraftQualityDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<QuestionDraftQualityDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftQualityDto>>(data);
                return new BaseResponse<List<QuestionDraftQualityDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftQualityDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDraftQualityDto>>> GetByQuestion(int draftId)
        {
            try
            {
                var data = await _repository.GetByQuestion(draftId);
                if (data == null) return new BaseResponse<List<QuestionDraftQualityDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftQualityDto>>(data);
                return new BaseResponse<List<QuestionDraftQualityDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftQualityDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDraftQualityDto>>> GetByUser(int userId)
        {
            try
            {
                var data = await _repository.GetByUser(userId);
                if (data == null) return new BaseResponse<List<QuestionDraftQualityDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftQualityDto>>(data);
                return new BaseResponse<List<QuestionDraftQualityDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftQualityDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<QuestionDraftQualityDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<QuestionDraftQualityDto>(Get404());
                var dto = _mapper.Map<QuestionDraftQualityDto>(data);
                return new BaseResponse<QuestionDraftQualityDto>(dto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<QuestionDraftQualityDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(QuestionDraftQualityDto request)
        {
            try
            {
                var data = await _repository.GetByUserAndQuestion(request.CreatedBy,request.QuestionDraftId);
                if (data != null) return new BaseResponse<int>(Get400("Bu soru için kalite değerlendirmeniz zaten mevcut"));
                var entity = new QuestionDraftQuality
                {
                    CreatedBy = request.CreatedBy,
                    QuestionDraftId = request.QuestionDraftId,
                    QualityPoint = request.QualityPoint,
                    Feedback = request.Feedback,
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
        public async Task<BaseResponse<bool>> Update(QuestionDraftQualityDto request)
        {
            try
            {
                var data = await _repository.GetById(request.Id);
                if (data == null) return new BaseResponse<bool>(Get404());

                data.CreatedBy = request.CreatedBy;
                data.QuestionDraftId = request.QuestionDraftId;
                data.QualityPoint = request.QualityPoint;
                data.Feedback = request.Feedback;
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
