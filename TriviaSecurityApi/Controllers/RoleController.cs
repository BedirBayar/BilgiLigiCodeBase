using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.RoleModels;
using TriviaSecurityApi.Services.Role;

namespace TriviaSecurityApi.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService roleService)
        {
            _service = roleService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=>GetHttpResult(await _service.GetAll());
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)=> GetHttpResult(await _service.GetRoleById(id));
        [HttpPost("add")]
        public async Task<IActionResult> AddRole(RoleDto role)=> GetHttpResult(await _service.AddRole(role));
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRole(RoleDto role)=> GetHttpResult(await _service.UpdateRole(role));
        [HttpPut("changestatus")]
        public async Task<IActionResult> ChangeStatus(int id)=> GetHttpResult(await _service.ChangeRoleStatus(id));
        [HttpPut("archive")]
        public async Task<IActionResult> Archive(int id) => GetHttpResult(await _service.ArchiveRole(id));


    }
}
