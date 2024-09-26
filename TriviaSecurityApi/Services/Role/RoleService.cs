using AutoMapper;
using TriviaSecurityApi.DataLayer.Repositories;
using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.RoleModels;

namespace TriviaSecurityApi.Services.Role
{
    public class RoleService :IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;
        public RoleService( IRoleRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<RoleDto>>> GetAll()
        {
            var data = await _repository.GetAll();
            if (data != null)
            {
                var roles= _mapper.Map<List<RoleDto>>(data);    
                return new BaseResponse<List<RoleDto>> { Data = roles, Success = true };
            }
            return new BaseResponse<List<RoleDto>> { Error = new ErrorResponse { Code="404", Message="Veri Bulunamadı"}, Success = false };
        }
        public async Task<BaseResponse<RoleDto>> GetRoleById(int id)
        {
            var data = await _repository.GetRoleById(id);
            if (data != null)
            {
                var roles = _mapper.Map<RoleDto>(data);
                return new BaseResponse<RoleDto> { Data = roles, Success = true };
            }
            return new BaseResponse<RoleDto> { Error = new ErrorResponse { Code = "404", Message = "Veri Bulunamadı" }, Success = false };
        }
        public async Task<BaseResponse<int>> UpdateRole(RoleDto role)
        {
            var entity = await _repository.GetRoleById(role.Id);
            if (entity != null)
            {
                if (role.Name != entity.Name)
                {
                    var nameCheck= _repository.GetRoleByName(role.Name);    
                    if (nameCheck != null)
                    {
                        return new BaseResponse<int> { Error = new ErrorResponse { Code = "400", Message = "Aynı isimde bir rol mevcut" }, Success = false };
                    }
                }
                entity.Name = role.Name;
                entity.Description = role.Description;
                entity.UpdatedBy = 1;
                entity.UpdatedOn=DateTime.Now;
                await _repository.UpdateRole(entity);
                return new BaseResponse<int> { Data = entity.Id, Success = true };
            }
            return new BaseResponse<int> { Error = new ErrorResponse { Code = "404", Message = "Veri Bulunamadı" }, Success = false };
        }
        public async Task<BaseResponse<bool>> ChangeRoleStatus(int id)
        {
            var entity = await _repository.GetRoleById(id);
            if (entity != null)
            {
                entity.IsActive = !entity.IsActive;
                await _repository.UpdateRole(entity);
                return new BaseResponse<bool> { Data = entity.IsActive, Success = true };
            }
            return new BaseResponse<bool> { Error = new ErrorResponse { Code = "404", Message = "Veri Bulunamadı" }, Success = false };
        }

        public async Task<BaseResponse<bool>> ArchiveRole(int id)
        {
            var entity = await _repository.GetRoleById(id);
            if (entity != null)
            {
                entity.IsArchived = true;
                entity.ArchivedOn = DateTime.Now;
                entity.ArchivedBy = 1;
                await _repository.UpdateRole(entity);
                return new BaseResponse<bool> { Data = true, Success = true };
            }
            return new BaseResponse<bool> { Error = new ErrorResponse { Code = "404", Message = "Veri Bulunamadı" }, Success = false };
        }
        public async Task<BaseResponse<int>> AddRole(RoleDto role)
        {
            var nameCheck = await _repository.GetRoleByName(role.Name);
            if (nameCheck != null)
            {
                return new BaseResponse<int> { Error = new ErrorResponse { Code = "400", Message = "Aynı isimde bir rol mevcut" }, Success = false };    
            }
            var entity = new DataLayer.Entities.Role();
            entity.Name = role.Name;
            entity.Description = role.Description;
            entity.CreatedBy = 1;
            entity.CreatedOn = DateTime.Now;
            entity.IsArchived = false;
            entity.IsActive = true;
            var data= await _repository.AddRole(entity);
            if(data>0)return new BaseResponse<int> { Data = data, Success = true };
            
            return new BaseResponse<int> { Error = new ErrorResponse { Code = "500", Message = "bir hata oluştu" }, Success = false };
        }

    }
}
