using AutoMapper;
using TriviaContestApi.DataAccess.Repositories.Question_;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Services.Question_
{
    public class QuestionService : BaseService, IQuestionService
    {
        private readonly IQuestionRepository _repository;
        public QuestionService (IQuestionRepository repository,IMapper _mapper) : base(_mapper)
        { 
            _repository = repository; 
        }
        public async Task<BaseResponse<List<QuestionDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<QuestionDto>>(data);
                    return new BaseResponse<List<QuestionDto>>(list);
                }
                return new BaseResponse<List<QuestionDto>>(Get404());
            }
            catch (Exception ex) {
                return new BaseResponse<List<QuestionDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDto>>> GetByCategory(int categoryId)
        {
            try
            {
                var data = await _repository.GetByCategory(categoryId);
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<QuestionDto>>(data);
                    return new BaseResponse<List<QuestionDto>>(list);
                }
                return new BaseResponse<List<QuestionDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<QuestionDto>>> GetByDifficulty(int easy, int hard)
        {
            try
            {
                var data = await _repository.GetByDifficulty(easy,hard);
                if (data != null && data.Count > 0)
                {
                    var list = _mapper.Map<List<QuestionDto>>(data);
                    return new BaseResponse<List<QuestionDto>>(list);
                }
                return new BaseResponse<List<QuestionDto>>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<QuestionDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<QuestionDto>> GetById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);
                if (data != null)
                {
                    var dto = _mapper.Map<QuestionDto>(data);
                    return new BaseResponse<QuestionDto>(dto);
                }
                return new BaseResponse<QuestionDto>(Get404());
            }
            catch (Exception ex)
            {
                return new BaseResponse<QuestionDto>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> Add(QuestionDto question)
        {
            try
            {
                var entity = _mapper.Map<Question>(question);
                entity.CreatedOn = DateTime.Now;
                entity.IsActive = true;
                var id = await _repository.Add(entity);
                return new BaseResponse<int>(id);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<int>>> AddRange(List<QuestionDto> questions)
        {
            try
            {
                var entities = _mapper.Map<List<Question>>(questions);
               foreach (var entity in entities)
                {
                    entity.CreatedOn = DateTime.Now;
                    entity.IsActive = true;
                }
                var ids = await _repository.AddRange(entities);
                return new BaseResponse<List<int>>(ids);
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<int>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Update(QuestionDto question)
        {
            try
            {
                var entity= await _repository.GetById(question.Id);
                entity.Text = question.Text;
                entity.Choice1 = question.Choice1;
                entity.Choice2 = question.Choice2;
                entity.Choice3 = question.Choice3;
                entity.Choice4 = question.Choice4;
                entity.Answer= question.Answer;
                entity.Difficulty = question.Difficulty;
                entity.UpdatedOn = DateTime.Now;
                var result= await _repository.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> ChangeStatus(QuestionDto question)
        {
            try
            {
                var entity = await _repository.GetById(question.Id);
                entity.IsActive=!entity.IsActive;
                entity.UpdatedOn = DateTime.Now;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> Archive(QuestionDto question)
        {
            try
            {
                var entity = await _repository.GetById(question.Id);
                entity.IsArchived = !entity.IsArchived;
                entity.UpdatedOn = DateTime.Now;
                var result = await _repository.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }


    }
}
