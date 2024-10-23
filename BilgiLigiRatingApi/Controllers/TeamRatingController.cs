using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Services.TeamRating_;

namespace BilgiLigiRatingApi.Controllers
{
    [Route("api/teamrating")]
    [ApiController]
    public class TeamRatingController : BaseController
    {
        private readonly ITeamRatingService _service;
        public TeamRatingController(ITeamRatingService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=>GetHttpResult(await _service.GetAll());  
        [HttpGet("getbyteam")]
        public async Task<IActionResult> GetByTeam(int teamId)=>GetHttpResult(await _service.GetByTeam(teamId));  
        [HttpGet("getbyratinginterval")]
        public async Task<IActionResult> GetByRatingInterval(int min, int max)=>GetHttpResult(await _service.GetByRatingInterval(min, max));  
        [HttpPost("add")]
        public async Task<IActionResult> Add(TeamRatingDto request) =>GetHttpResult(await _service.Add(request));  
        [HttpPut("update")]
        public async Task<IActionResult> Update(TeamRatingDto request) =>GetHttpResult(await _service.Update(request));  
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int teamId) =>GetHttpResult(await _service.Delete(teamId));  

    }
}
