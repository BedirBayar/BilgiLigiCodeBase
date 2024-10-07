using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaRatingApi.Models;

namespace TriviaRatingApi.Controllers
{
    [Route("api/userrank")]
    [ApiController]
    public class UserRankController : ControllerBase
    {
        private List<string> Ranks = new List<string>
        {
            "Acemi",
            "Bilgisiz",
            "Vatandaş",
            "Eğitimli",
            "Bilge",
            "Stratejist"
        };
        [HttpGet("getuserrank")]
        public IActionResult Get(int id)
        {
            var data= Ranks[id % 6];

            return Ok(new BaseResponse<string> { Data = data });
        }
    }
}

