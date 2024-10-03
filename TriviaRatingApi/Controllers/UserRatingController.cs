using Microsoft.AspNetCore.Mvc;

namespace TriviaRatingApi.Controllers
{
    [ApiController]
    [Route("api/userrating")]
    public class UserRatingController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserRatingController> _logger;

        public UserRatingController(ILogger<UserRatingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getuserrating")]
        public decimal Get(int id)
        {
            return (decimal)Math.Round(id * Math.PI,2);
        }
    }
}
