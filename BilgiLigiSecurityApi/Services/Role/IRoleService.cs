using BilgiLigiSecurityApi.DTOs;
using BilgiLigiSecurityApi.DTOs.RoleModels;

namespace BilgiLigiSecurityApi.Services.Role
{
    public interface IRoleService
    {
        Task<BaseResponse<List<RoleDto>>> GetAll();
        Task<BaseResponse<RoleDto>> GetRoleById(int id);
        Task<BaseResponse<bool>> UpdateRole(RoleDto user);
        Task<BaseResponse<bool>> ChangeRoleStatus(int id);
        Task<BaseResponse<bool>> ArchiveRole(int id);
        Task<BaseResponse<int>> AddRole(RoleDto user);
    }
}
