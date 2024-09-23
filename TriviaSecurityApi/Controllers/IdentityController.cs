using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.IdentityModels;
using TriviaSecurityApi.Services.Identity;

namespace TriviaSecurityApi.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost("login")]
        public async Task<BaseResponse<TokenResponse>> Login(TokenRequest request)
        {
            return await _identityService.GetToken(request);
        }
        [HttpPost("register")]
        public async Task<BaseResponse<RegisterResponse>> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                return await _identityService.Register(request);
            }
            return new BaseResponse<RegisterResponse> { Error = new ErrorResponse { Code = "400", Message = "Bilgiler eksik veya hatalı" } };
        }
        [HttpPost("changepassword")]
        public async Task<BaseResponse<bool>> ChangePassword(ChangePasswordRequest request)
        {

            if (ModelState.IsValid && request.OldPassword!=request.NewPassword)
            {
                return await _identityService.ChangePassword(request);
            }
            return new BaseResponse<bool> { Error = new ErrorResponse { Code = "400", Message = "Bilgiler eksik veya hatalı" } };
        } 
    }
}
