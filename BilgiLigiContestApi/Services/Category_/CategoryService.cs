using Microsoft.IdentityModel.Logging;
using BilgiLigiContestApi.DataAccess.Repositories.Category_;
using BilgiLigiContestApi.DTOs;
using BilgiLigiContestApi.DataAccess.Entities;
using AutoMapper;

namespace BilgiLigiContestApi.Services.Category_
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRep;
        public CategoryService(ICategoryRepository categoryRepository, IMapper _mapper, AuthenticatedUserService _aus):base(_mapper, _aus) {
            _categoryRep = categoryRepository;
        }
        public async Task<BaseResponse<int>> Add(CategoryDto cat)
        {
            try
            {
                var exist = await _categoryRep.GetByName(cat.Name);
                if (exist != null) return new BaseResponse<int>(Get400("Aynı isimde bir kategori mevcut"));
            
                var entity = new Category
                {
                    Name = cat.Name,
                    Description = cat.Description,
                    IsActive = cat.IsActive,
                    CreatedOn = DateTime.Now,
                    CreatedBy = _aus.UserId
                };
                int result = await _categoryRep.Add(entity);
                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<List<CategoryDto>>> GetAll()
        {
            try
            {
                var entities = await _categoryRep.GetAll();
                var data = _mapper.Map<List<CategoryDto>>(entities);
                return new BaseResponse<List<CategoryDto>>(data);
            }
            catch(Exception ex) 
            {
                return new BaseResponse<List<CategoryDto>>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<List<CategoryDto>>> GetAllActive()
        {
            try
            {
                var entities = await _categoryRep.GetAllActive();
                var data = _mapper.Map<List<CategoryDto>>(entities);
                return new BaseResponse<List<CategoryDto>>(data);
            }
            catch(Exception ex)
            {
                return new BaseResponse<List<CategoryDto>>(Get500(ex.Message));
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
            catch (Exception ex)
            {
                return new BaseResponse<CategoryDto>(Get500(ex.Message));
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
            catch (Exception ex)
            {
                return new BaseResponse<CategoryDto>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Update(CategoryDto cat)
        {
            try
            {
                var entity = await _categoryRep.GetById(cat.Id);
                if (entity == null) return new BaseResponse<bool>(Get404("Kategori Bulunamadı"));
                entity.Name = cat.Name;
                entity.Description = cat.Description;
                entity.IsActive = cat.IsActive;
                entity.UpdatedBy = -_aus.UserId;
                entity.UpdatedOn = DateTime.Now;
                
                bool result = await _categoryRep.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }

        public async Task<BaseResponse<bool>> Archive(int id)
        {
            try
            {
                var entity = await _categoryRep.GetById(id);
                if (entity == null) return new BaseResponse<bool>(Get404("Kategori Bulunamadı"));
                entity.IsActive = false;
                entity.IsArchived = true;
                entity.ArchivedBy = _aus.UserId;
                entity.ArchivedOn = DateTime.Now;
                bool result = await _categoryRep.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
            
        }
    
        public async Task<BaseResponse<bool>> ArchiveByName(string name)
        {
            try
            {
                var entity = await _categoryRep.GetByName(name);
                if (entity == null)
                return new BaseResponse<bool>(Get404("Kategori bulunamadı"));
            
                entity.IsActive = false;
                entity.IsArchived = true;
                entity.ArchivedBy = _aus.UserId;
                entity.ArchivedOn = DateTime.Now;
                bool result = await _categoryRep.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> ChangeStatus(int id)
        {
            try
            {
                var entity = await _categoryRep.GetById(id);
                if (entity == null)  return new BaseResponse<bool>(Get404("Kategori bulunamadı"));
                entity.IsActive = !entity.IsActive;
                entity.UpdatedBy = _aus.UserId;
                entity.UpdatedOn = DateTime.Now;

                bool result = await _categoryRep.Update(entity);
                return new BaseResponse<bool>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
            
        }
    }
}
