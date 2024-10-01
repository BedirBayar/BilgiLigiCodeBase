using Microsoft.IdentityModel.Logging;
using TriciaContestApi.DTOs;
using TriviaContestApi.DataAccess.Repositories.Category_;
using TriviaContestApi.DTOs;
using TriviaContestApi.DataAccess.Entities;
using AutoMapper;

namespace TriviaContestApi.Services.Category_
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRep;
        private IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) {
            _categoryRep = categoryRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<int>> Add(CategoryDto cat)
        {
            var exist = await _categoryRep.GetByName(cat.Name);
            if (exist == null)
            {
                var entity = new Category
                {
                    Name = cat.Name,
                    Description = cat.Description,
                    IsActive = cat.IsActive,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now
                };
                try
                {
                    int result = await _categoryRep.Add(entity);
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

        public async Task<BaseResponse<List<CategoryDto>>> GetAll()
        {
            try
            {
                var entities = await _categoryRep.GetAll();
                var data = _mapper.Map<List<CategoryDto>>(entities);
                return new BaseResponse<List<CategoryDto>>(data);
            }
            catch(Exception Ex) 
            {
                var error = new ErrorResponse
                {
                    Code = "500",
                    Message = Ex.Message
                };
                return new BaseResponse<List<CategoryDto>> (error);
            }
        }

        public async Task<BaseResponse<CategoryDto>> GetById(int id)
        {
            try
            {
                var entity = await _categoryRep.GetById(id);
                var data = _mapper.Map<CategoryDto>(entity);
                return new BaseResponse<CategoryDto>(data);
            }
            catch (Exception Ex)
            {
                var error = new ErrorResponse
                {
                    Code = "500",
                    Message = Ex.Message
                };
                return new BaseResponse<CategoryDto>(error);
            }
        }

        public async Task<BaseResponse<CategoryDto>> GetByName(string name)
        {
            try
            {
                var entity = await _categoryRep.GetByName(name);
                var data = _mapper.Map<CategoryDto>(entity);
                return new BaseResponse<CategoryDto>(data);
            }
            catch (Exception Ex)
            {
                var error = new ErrorResponse
                {
                    Code = "500",
                    Message = Ex.Message
                };
                return new BaseResponse<CategoryDto>(error);
            }
        }

        public async Task<BaseResponse<bool>> Update(CategoryDto cat)
        {
            var entity = await _categoryRep.GetById(cat.Id);
            if (entity != null)
            {

                entity.Name = cat.Name;
                entity.Description = cat.Description;
                entity.IsActive = cat.IsActive;
                entity.UpdatedBy = 1;
                entity.UpdatedOn = DateTime.Now;
                
                try
                {
                    bool result = await _categoryRep.Update(entity);
                    return new BaseResponse<bool>(result);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<bool>
                    {
                        Data = false,
                        Success = false,
                        Error = new ErrorResponse
                        {
                            Code = "500",
                            Message = ex.Message,
                        }
                    };
                }
            }
            return new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                Error = new ErrorResponse
                {
                    Code = "400",
                    Message = "Aynı isimde bir kategori mevcut",
                }
            };
        }

        public async Task<BaseResponse<bool>> Archive(int id)
        {
            var entity = await _categoryRep.GetById(id);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsArchived = true;
                entity.UpdatedBy = 1;
                entity.UpdatedOn = DateTime.Now;

                try
                {
                    bool result = await _categoryRep.Update(entity);
                    return new BaseResponse<bool>(result);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<bool>
                    {
                        Data = false,
                        Success = false,
                        Error = new ErrorResponse
                        {
                            Code = "500",
                            Message = ex.Message,
                        }
                    };
                }
            }
            return new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                Error = new ErrorResponse
                {
                    Code = "400",
                    Message = "Aynı isimde bir kategori mevcut",
                }
            };
        }
    
        public async Task<BaseResponse<bool>> ArchiveByName(string name)
        {
            var entity = await _categoryRep.GetByName(name);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsArchived = true;
                entity.UpdatedBy = 1;
                entity.UpdatedOn = DateTime.Now;

                try
                {
                    bool result = await _categoryRep.Update(entity);
                    return new BaseResponse<bool>(result);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<bool>
                    {
                        Data = false,
                        Success = false,
                        Error = new ErrorResponse
                        {
                            Code = "500",
                            Message = ex.Message,
                        }
                    };
                }
            }
            return new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                Error = new ErrorResponse
                {
                    Code = "400",
                    Message = "Aynı isimde bir kategori mevcut",
                }
            };
        }
        public async Task<BaseResponse<bool>> ChangeStatus(int id)
        {
            var entity = await _categoryRep.GetById(id);
            if (entity != null)
            {
                entity.IsActive = !entity.IsActive;
                entity.IsArchived = false;
                entity.UpdatedBy = 1;
                entity.UpdatedOn = DateTime.Now;

                try
                {
                    bool result = await _categoryRep.Update(entity);
                    return new BaseResponse<bool>(result);
                }
                catch (Exception ex)
                {
                    return new BaseResponse<bool>
                    {
                        Data = false,
                        Success = false,
                        Error = new ErrorResponse
                        {
                            Code = "500",
                            Message = ex.Message,
                        }
                    };
                }
            }
            return new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                Error = new ErrorResponse
                {
                    Code = "400",
                    Message = "Aynı isimde bir kategori mevcut",
                }
            };
        }
    }
}
