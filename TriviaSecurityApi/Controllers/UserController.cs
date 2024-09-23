using Microsoft.AspNetCore.Mvc;
using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.UserModels;
using TriviaSecurityApi.Services.User;

namespace TriviaSecurityApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<BaseResponse<List<UserDto>>> GetAll()=> await _service.GetAll();
        
        [HttpGet("getbyid")]
        public async Task<BaseResponse<UserDto>> GetUserById(int id) => await _service.GetUserById(id);
        
        [HttpGet("getbyusername")]
        public async Task<BaseResponse<UserDto>> GetUserByUsername(string userName) => await _service.GetUserByUsername(userName);
        
        [HttpGet("getbyemail")]
        public async Task<BaseResponse<UserDto>> GetUserByEmail(string email) => await _service.GetUserByEmail(email);
        
        //[HttpPost("add")]
        //public async Task<BaseResponse<int>> AddUser(UserDto user) => await _service.AddUser(user);
        
        [HttpPut("update")]
        public async Task<BaseResponse<int>> UpdateUser(UserDto user)=> await _service.UpdateUser(user);
        
        [HttpPut("ban")]
        public async Task<BaseResponse<int>> BanUser(BanUserRequest user)=> await _service.BanUser(user);
        
        [HttpPut("archive")]
        public async Task<BaseResponse<int>> ArchiveUser(int id) => await _service.ArchiveUser(id);
        

    }
}
