using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiContestApi.DTOs;
using BilgiLigiContestApi.Services.LeaderBoard_;

namespace BilgiLigiContestApi.Controllers
{
    [Route("api/leaderboard")]
    [ApiController]
    public class LeaderBoardController : BaseController
    {
        private readonly ILeaderBoardService _service;
        public LeaderBoardController(ILeaderBoardService service)
        {
            _service = service;
        }
        [HttpGet("getallincomplete")]
        public async Task<IActionResult> GetAllIncomplete() => GetHttpResult(await _service.GetAllIncomplete());
        [HttpGet("getallcomplete")]
        public async Task<IActionResult> GetAllComplete(DateTime startDate, DateTime endDate) => GetHttpResult(await _service.GetAllComplete(startDate, endDate));
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id) => GetHttpResult(await _service.GetById(id));
        [HttpPut("update")]
        public async Task<IActionResult> Update(LeaderBoardDto dto) => GetHttpResult(await _service.Update(dto));
    }
}
