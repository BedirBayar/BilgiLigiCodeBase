using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaRatingApi.Models;

namespace TriviaRatingApi.Controllers
{
    [Route("api/useraward")]
    [ApiController]
    public class UserAwardController : ControllerBase
    {

        [HttpGet("getuserawards")]
        public IActionResult GetUserAwards(int id) {
            var data = new List<string> {
                "7 Kazanma Serisi Ödülü",
                "Yüksek Puanlı Rakibi Yenme Ödülü"
            };
            return Ok(new BaseResponse<List<string>> { Data=data});
        }
    }
}
