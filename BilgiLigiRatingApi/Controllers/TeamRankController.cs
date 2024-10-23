using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Services.TeamRank_;

namespace BilgiLigiRatingApi.Controllers
{
    [Route("api/teamrank")]
    [ApiController]
    public class TeamRankController : BaseController
    {
        private readonly ITeamRankService _service;
        public TeamRankController(ITeamRankService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=>GetHttpResult(await _service.GetAll());
        [HttpGet("getteamrank")]
        public async Task<IActionResult> GetTeamRank( int teamId)=>GetHttpResult(await _service.GetTeamRank(teamId));
        [HttpPut("update")]
        public async Task<IActionResult> Update(TeamRankDto request)=>GetHttpResult(await _service.Update(request));
        [HttpPost("add")]
        public async Task<IActionResult> Add(TeamRankDto request) =>GetHttpResult(await _service.Add(request));
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int teamId) =>GetHttpResult(await _service.Delete(teamId));
    }
}
