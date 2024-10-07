using Microsoft.AspNetCore.Mvc;
using TriviaRatingApi.Models;

namespace TriviaRatingApi.Controllers
{
    [ApiController]
    [Route("api/userrating")]
    public class UserRatingController : ControllerBase
    {
        [HttpGet("getuserrating")]
        public IActionResult Get(int id)
        {
            var data = (decimal)Math.Round(id * Math.PI, 2);
            return Ok(new BaseResponse<decimal>(data));
        }
    }
}
