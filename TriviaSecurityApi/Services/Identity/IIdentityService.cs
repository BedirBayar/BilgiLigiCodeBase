using TriviaSecurityApi.DTOs;
using TriviaSecurityApi.DTOs.IdentityModels;

namespace TriviaSecurityApi.Services.Identity
{
    public interface IIdentityService
    {
        Task<BaseResponse<TokenResponse>> GetToken(TokenRequest request);
        Task<BaseResponse<RegisterResponse>> Register(RegisterRequest request);
        Task<BaseResponse<bool>> ChangePassword(ChangePasswordRequest request);
    }
}
