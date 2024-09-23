using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.RoleModels;
using TriviaSecurityApi.Services.Role;

namespace TriviaSecurityApi.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService roleService)
        {
            _service = roleService;
        }

        [HttpGet("getall")]
        public async Task<BaseResponse<List<RoleDto>>> GetAll()=>await _service.GetAll();
        [HttpGet("getbyid")]
        public async Task<BaseResponse<RoleDto>> GetById(int id)=>await _service.GetRoleById(id);
        [HttpPost("add")]
        public async Task<BaseResponse<int>> AddRole(RoleDto role)=>await _service.AddRole(role);
        [HttpPut("update")]
        public async Task<BaseResponse<int>> UpdateRole(RoleDto role)=>await _service.UpdateRole(role);
        [HttpPut("changestatus")]
        public async Task<BaseResponse<bool>> ChangeStatus(int id)=>await _service.ChangeRoleStatus(id);
        [HttpPut("archive")]
        public async Task<BaseResponse<bool>> Archive(int id) => await _service.ArchiveRole(id);


    }
}
