using Microsoft.AspNetCore.Mvc;
using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.UserModels;
using TriviaSecurityApi.Services.User;

namespace TriviaSecurityApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=> GetHttpResult(await _service.GetAll());
        
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetUserById(int id) => GetHttpResult(await _service.GetUserById(id));
        
        [HttpGet("getbyusername")]
        public async Task<IActionResult> GetUserByUsername(string userName) => GetHttpResult(await _service.GetUserByUsername(userName));
        
        [HttpGet("getbyemail")]
        public async Task<IActionResult> GetUserByEmail(string email) => GetHttpResult(await _service.GetUserByEmail(email));
        
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(UserDto user) => GetHttpResult(await _service.UpdateUser(user));
        
        [HttpPut("banunban")]
        public async Task<IActionResult> BanUser(BanUserRequest user) => GetHttpResult(await _service.BanUser(user));
        
        [HttpPut("archive")]
        public async Task<IActionResult> ArchiveUser(int id) => GetHttpResult(await _service.ArchiveUser(id));
        

    }
}
