using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiContestApi.Services.Match_;

namespace BilgiLigiContestApi.Controllers
{
    [Route("api/teammatch")]
    [ApiController]
    public class TeamMatchController : BaseController
    {
        private readonly ITeamMatchService _matchService;
        public TeamMatchController(ITeamMatchService matchService)
        {
            _matchService = matchService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => GetHttpResult(await _matchService.GetAll());
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id) => GetHttpResult(await _matchService.GetById(id));
        [HttpGet("getbycontest")]
        public async Task<IActionResult> GetByContest(int contestId) => GetHttpResult(await _matchService.GetByContest(contestId));
        [HttpGet("getbydate")]
        public async Task<IActionResult> GetByDate(DateTime startDate, DateTime endDate) => Ok();
        [HttpGet("getbyteam")]
        public async Task<IActionResult> GetByTeam(int userId) => GetHttpResult(await _matchService.GetByTeam(userId));
    }
}
