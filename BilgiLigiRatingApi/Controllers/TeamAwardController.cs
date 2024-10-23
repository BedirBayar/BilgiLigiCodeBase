using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiRatingApi.Models.TeamModels;
using BilgiLigiRatingApi.Services.TeamAward_;

namespace BilgiLigiRatingApi.Controllers
{
    [Route("api/teamaward")]
    [ApiController]
    public class TeamAwardController : BaseController
    {
        private readonly ITeamAwardService _service;
        public TeamAwardController(ITeamAwardService service)
        {
            _service = service;
        }
        [HttpGet("getteamawards")]
        public async Task<IActionResult> GetTeamAwards(int teamId) => GetHttpResult(await _service.GetTeamAwards(teamId));
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddTeamAwardRequest request) => GetHttpResult(await _service.Add(request));
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(AddTeamAwardRequest request) => GetHttpResult(await _service.Delete(request));
    }
}
