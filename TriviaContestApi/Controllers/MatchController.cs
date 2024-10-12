using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TriviaContestApi.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        [HttpGet("getbyid")]
        public IActionResult GetById(int id) => Ok();
        [HttpGet("getbyleague")]
        public IActionResult GetByLeague(int leagueId) => Ok();
        [HttpGet("getbycontest")]
        public IActionResult GetByContest(int contestId) => Ok();
        [HttpGet("getbydate")]
        public IActionResult GetByDate(DateTime startDate, DateTime endDate) => Ok();
        [HttpGet("getbyuser")]
        public IActionResult GetByUser(int userId, DateTime? startDate, DateTime? endDate) => Ok();
        [HttpGet("getbyteam")]
        public IActionResult GetByTeam(int teamId, DateTime? startDate, DateTime? endDate) => Ok();


    }
}
