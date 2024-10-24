using System.Security.Claims;

namespace BilgiLigiContestApi.Services
{
    public class AuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue("uid"));
            UserContext = httpContextAccessor.HttpContext?.User?.FindFirstValue("user_context");
        }

        public int UserId { get; }
        public string Username { get; }
        public string AuthenticatedApplicationCode { get; }
        public string UserContext { get; }
    }
}
