using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TriviaContestApi.Services.Match_;

namespace TriviaContestApi.Controllers
{
    [Route("api/usermatch")]
    [ApiController]
    public class UserMatchController : BaseController
    {
        private readonly IUserMatchService _matchService;
        public UserMatchController(IUserMatchService matchService)
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
        [HttpGet("getbyuser")]         
        public async Task<IActionResult> GetByUser(int userId) => GetHttpResult(await _matchService.GetByUser(userId));
    }
}
