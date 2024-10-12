using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaRatingApi.Models;
using TriviaRatingApi.Models.RankModels;

namespace TriviaRatingApi.Controllers
{
    [Route("api/userrank")]
    [ApiController]
    public class UserRankController : ControllerBase
    {
        private List<UserRankResponse> Ranks = new List<UserRankResponse>
        {
            new UserRankResponse{ RankNumber=1, RankName= "Acemi" },
            new UserRankResponse{ RankNumber=2, RankName= "Tecrubeli" },
            new UserRankResponse{ RankNumber=3, RankName= "Öğretmen" },
            new UserRankResponse{ RankNumber=4, RankName= "Bilge" },
            new UserRankResponse{ RankNumber=5, RankName= "Profesör" },
            new UserRankResponse{ RankNumber=6, RankName= "Alim" },
            new UserRankResponse{ RankNumber=7, RankName= "Ansiklopedi" },
            new UserRankResponse{ RankNumber=8, RankName= "Kütüphane" },
            new UserRankResponse{ RankNumber=9, RankName= "Veritabanı" },
            new UserRankResponse{ RankNumber=10, RankName= "Enerji" },
        };
        [HttpGet("getuserrank")]
        public IActionResult Get(int id)
        {
            var data= Ranks[id % 10];

            return Ok(new BaseResponse<UserRankResponse> { Data = data });
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(new BaseResponse<List<UserRankResponse>>(Ranks));
        }
    }
}

