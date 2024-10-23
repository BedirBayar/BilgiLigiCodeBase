using AutoMapper;
using BilgiLigiContestApi.Services;
using BilgiLigiSecurityApi.DataLayer.Repositories;
using BilgiLigiSecurityApi.DTOs;
using BilgiLigiSecurityApi.DTOs.RoleModels;

namespace BilgiLigiSecurityApi.Services.Role
{
    public class RoleService :BaseService,IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService( IRoleRepository repository, IMapper _mapper):base(_mapper) {
            _repository = repository;
        }

        public async Task<BaseResponse<List<RoleDto>>> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
                if (data == null)
                return new BaseResponse<List<RoleDto>>(Get404());
                var roles = _mapper.Map<List<RoleDto>>(data);
                return new BaseResponse<List<RoleDto>>(roles);
            }
            catch (Exception ex) {
                return new BaseResponse<List<RoleDto>>(Get500(ex.Message));
            }
            
        }
        public async Task<BaseResponse<RoleDto>> GetRoleById(int id)
        {
            try
            {
                var data = await _repository.GetRoleById(id);
                if (data == null) return new BaseResponse<RoleDto>(Get404());
                var role = _mapper.Map<RoleDto>(data);
                return new BaseResponse<RoleDto>(role);
            }
            catch (Exception ex)
            {
                return new BaseResponse<RoleDto>(Get500(ex.Message));
            }
           
        }
        public async Task<BaseResponse<bool>> UpdateRole(RoleDto role)
        {
            try
            {
                var entity = await _repository.GetRoleById(role.Id);
                if (entity == null)
                return new BaseResponse<bool>(Get404());
                if (role.Name != entity.Name) // Checking if new name is already in use
                {
                    var nameCheck = _repository.GetRoleByName(role.Name);
                    if (nameCheck != null) return new BaseResponse<bool>(Get400("Aynı isimde bir rol mevcut"));
                }
                entity.Name = role.Name;
                entity.Description = role.Description;
                entity.UpdatedBy = 1;
                entity.UpdatedOn = DateTime.Now;
                var result= await _repository.UpdateRole(entity);
                return new BaseResponse<bool>(result);
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<bool>> ChangeRoleStatus(int id)
        {
            try
            {
                var entity = await _repository.GetRoleById(id);
                if (entity == null)
                return new BaseResponse<bool>(Get404());
                entity.IsActive = !entity.IsActive;
                await _repository.UpdateRole(entity);
                return new BaseResponse<bool> { Data = entity.IsActive, Success = true };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
            
        }

        public async Task<BaseResponse<bool>> ArchiveRole(int id)
        {
            try
            {
                var entity = await _repository.GetRoleById(id);
                if (entity == null)
                    return new BaseResponse<bool>(Get404());
                entity.IsArchived = true;
                entity.ArchivedOn = DateTime.Now;
                entity.ArchivedBy = 1;
                await _repository.UpdateRole(entity);
                return new BaseResponse<bool>(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>(Get500(ex.Message));
            }
        }
        public async Task<BaseResponse<int>> AddRole(RoleDto role)
        {
            try
            {
                var nameCheck = await _repository.GetRoleByName(role.Name);
                if (nameCheck != null)return new BaseResponse<int>(Get400("Aynı isimde bir rol mevcut"));
                
                var entity = new DataLayer.Entities.Role();
                entity.Name = role.Name;
                entity.Description = role.Description;
                entity.CreatedBy = 1;
                entity.CreatedOn = DateTime.Now;
                entity.IsArchived = false;
                entity.IsActive = true;
                var result = await _repository.AddRole(entity);
                return new BaseResponse<int>(result);
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>(Get500(ex.Message));
            }
            
            
        }

    }
}
