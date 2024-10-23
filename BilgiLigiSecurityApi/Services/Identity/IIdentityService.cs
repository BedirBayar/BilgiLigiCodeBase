using BilgiLigiSecurityApi.DTOs;
using BilgiLigiSecurityApi.DTOs.IdentityModels;

namespace BilgiLigiSecurityApi.Services.Identity
{
    public interface IIdentityService
    {
        Task<BaseResponse<TokenResponse>> GetToken(TokenRequest request);
        Task<BaseResponse<RegisterResponse>> Register(RegisterRequest request);
        Task<BaseResponse<bool>> ChangePassword(ChangePasswordRequest request);
    }
}
