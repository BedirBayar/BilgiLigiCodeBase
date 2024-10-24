using AutoMapper;
using BilgiLigiContributionApi.DataLayer.Relationships;
using BilgiLigiContributionApi.DataLayer.Repositories.QuestionQuality_;
using BilgiLigiContributionApi.DTOs;

namespace BilgiLigiContributionApi.Services
{
    public class QuestionQualityService : BaseService
    {
        private readonly IQuestionQualityRepository _repository;
        public QuestionQualityService(IQuestionQualityRepository repository, IMapper _mapper, AuthenticatedUserService _aus) : base(_mapper, _aus)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<QuestionQualityDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<QuestionQualityDto>>(Get404());
                var list = _mapper.Map<List<QuestionQualityDto>>(data);
                return new BaseResponse<List<QuestionQualityDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionQualityDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionQualityDto>>> GetByQuestion(int draftId)
        {
            try
            {
                var data = await _repository.GetByQuestion(draftId);
                if (data == null) return new BaseResponse<List<QuestionQualityDto>>(Get404());
                var list = _mapper.Map<List<QuestionQualityDto>>(data);
                return new BaseResponse<List<QuestionQualityDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionQualityDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionQualityDto>>> GetByUser(int userId)
        {
            try
            {
                var data = await _repository.GetByUser(userId);
                if (data == null) return new BaseResponse<List<QuestionQualityDto>>(Get404());
                var list = _mapper.Map<List<QuestionQualityDto>>(data);
                return new BaseResponse<List<QuestionQualityDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionQualityDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<QuestionQualityDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<QuestionQualityDto>(Get404());
                var dto = _mapper.Map<QuestionQualityDto>(data);
                return new BaseResponse<QuestionQualityDto>(dto);
            }
            catch (Exception ex)
            {
                return new BaseResponse<QuestionQualityDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(QuestionQualityDto request)
        {
            try
            {
                var data = await _repository.GetByUserAndQuestion(request.CreatedBy, request.QuestionId);
                if (data != null) return new BaseResponse<int>(Get400("Bu soru için kalite değerlendirmeniz zaten mevcut"));
                var entity = new QuestionQuality
                {
                    CreatedBy = request.CreatedBy,
                    QuestionId = request.QuestionId,
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
        public async Task<BaseResponse<bool>> Update(QuestionQualityDto request)
        {
            try
            {
                var data = await _repository.GetById(request.Id);
                if (data == null) return new BaseResponse<bool>(Get404());

                data.UpdatedBy = request.CreatedBy;
                data.QuestionId = request.QuestionId;
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
