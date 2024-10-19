using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaRatingApi.DTOs;
using TriviaRatingApi.Services.UserRating_;
using TriviaRatingApi.Services.UserTeam_;

namespace TriviaRatingApi.Controllers
{
    [Route("api/userteam")]
    [ApiController]
    public class UserTeamController : BaseController
    {

        private readonly IUserTeamService _service;
        public UserTeamController(IUserTeamService service)
        {
            _service = service;
        }
        [HttpGet("getuserteams")]
        public async Task<IActionResult> GetUserTeams(int userId)=>GetHttpResult(await _service.GetUserTeams(userId));
        [HttpGet("getteamusers")]
        public async Task<IActionResult> GetTeamUsers(int teamId)=>GetHttpResult(await _service.GetTeamUsers(teamId));
        [HttpPost("addusertoteam")]
        public async Task<IActionResult> AddUserToTeam(UserTeamDto request) =>GetHttpResult(await _service.AddUserToTeam(request));
        [HttpDelete("removeuserfromteam")]
        public async Task<IActionResult> RemoveUserFromTeam(UserTeamDto request) =>GetHttpResult(await _service.RemoveUserFromTeam(request));
        [HttpDelete("dissolveteam")]
        public async Task<IActionResult> DissolveTeam(int teamId) =>GetHttpResult(await _service.DissolveTeam(teamId));
    }
}
