using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.IdentityModels;
using TriviaSecurityApi.Services.Identity;

namespace TriviaSecurityApi.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(TokenRequest request) => GetHttpResult( await _identityService.GetToken(request));
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request) => GetHttpResult(await _identityService.Register(request));
        
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request) => GetHttpResult(await _identityService.ChangePassword(request));
        
    }
}
