using AutoMapper;
using TriviaContributionApi.DataLayer.Entities;
using TriviaContributionApi.DataLayer.Repositories.QuestionDraft_;
using TriviaContributionApi.DTOs;

namespace TriviaContributionApi.Services
{
    public class QuestionDraftService : BaseService
    {
        private readonly IQuestionDraftRepository _repository;
        public QuestionDraftService(IQuestionDraftRepository repository, IMapper _mapper) : base(_mapper)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<List<QuestionDraftDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null) return new BaseResponse<List<QuestionDraftDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftDto>>(data);
                return new BaseResponse<List<QuestionDraftDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDraftDto>>> GetByCategory(int categoryId)
        {
            try
            {
                var data = await _repository.GetByCategory(categoryId);
                if (data == null) return new BaseResponse<List<QuestionDraftDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftDto>>(data);
                return new BaseResponse<List<QuestionDraftDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDraftDto>>> GetByContributor(int userId)
        {
            try
            {
                var data = await _repository.GetByContributor(userId);
                if (data == null) return new BaseResponse<List<QuestionDraftDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftDto>>(data);
                return new BaseResponse<List<QuestionDraftDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDraftDto>>> GetByIdList(List<int> ids)
        {
            try
            {
                var data = await _repository.GetByIdList(ids);
                if (data == null) return new BaseResponse<List<QuestionDraftDto>>(Get404());
                var list = _mapper.Map<List<QuestionDraftDto>>(data);
                return new BaseResponse<List<QuestionDraftDto>>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDraftDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<QuestionDraftDto>> GetById(int ids)
        {
            try
            {
                var data = await _repository.GetById(ids);
                if (data == null) return new BaseResponse<QuestionDraftDto>(Get404());
                var list = _mapper.Map<QuestionDraftDto>(data);
                return new BaseResponse<QuestionDraftDto>(list);
            }
            catch (Exception ex)
            {
                return new BaseResponse<QuestionDraftDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(QuestionDraftDto request)
        {
            try
            {
                var entity = new QuestionDraft
                {
                    Text = request.Text,
                    CategoryId = request.CategoryId,
                    Answer = request.Answer,
                    Image = request.Image,
                    Choice1 = request.Choice1,
                    Choice2 = request.Choice2,
                    Choice3 = request.Choice3,
                    Choice4 = request.Choice4,
                    CreatedOn = DateTime.Now
                };
                var data = await _repository.Add(entity);
                return new BaseResponse<int>(data);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Update(QuestionDraftDto request)
        {
            try
            {
                var entity = await _repository.GetById(request.Id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                entity.Text = request.Text;
                entity.CategoryId = request.CategoryId;
                entity.Answer = request.Answer;
                entity.Image = request.Image;
                entity.Choice1 = request.Choice1;
                entity.Choice2 = request.Choice2;
                entity.Choice3 = request.Choice3;
                entity.Choice4 = request.Choice4;
                entity.UpdatedOn = DateTime.Now;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(result);
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
                var entity = await _repository.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404());
                var result = await _repository.Delete(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
    }
}
