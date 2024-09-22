using TriviaSecurityApi.DTOs.UserModels;

namespace TriviaSecurityApi.DTOs.IdentityModels
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public UserDto User { get; set; }

    }
}
