using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.RoleModels;

namespace TriviaSecurityApi.Services.Role
{
    public interface IRoleService
    {
        Task<BaseResponse<List<RoleDto>>> GetAll();
        Task<BaseResponse<RoleDto>> GetRoleById(int id);
        Task<BaseResponse<int>> UpdateRole(RoleDto user);
        Task<BaseResponse<bool>> ChangeRoleStatus(int id);
        Task<BaseResponse<bool>> ArchiveRole(int id);
        Task<BaseResponse<int>> AddRole(RoleDto user);
    }
}
