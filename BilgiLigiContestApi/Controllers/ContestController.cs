using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiContestApi.DTOs;
using BilgiLigiContestApi.Models.ContestModels;
using BilgiLigiContestApi.Services.Contest_;

namespace BilgiLigiContestApi.Controllers
{
    [Route("api/contest")]
    [ApiController]
    public class ContestController : BaseController
    {
        private readonly IContestService _contestService;

        public ContestController(IContestService contestService) {  
            _contestService = contestService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => GetHttpResult(await  _contestService.GetAll());
        [HttpGet("getallunfinished")]
        public async Task<IActionResult> GetAllUnfinished() => GetHttpResult(await  _contestService.GetAllUnfinished());
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id) => GetHttpResult(await _contestService.GetById(id));
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName(string name) => GetHttpResult(await _contestService.GetByName(name));
        [HttpPost("add")]
        public async Task<IActionResult> Add(ContestDto contest) => GetHttpResult(await _contestService.Add(contest));
        [HttpPut("update")]
        public async Task<IActionResult> Update(ContestDto contest) => GetHttpResult(await _contestService.Update(contest));
        [HttpPut("start")]
        public async Task<IActionResult> Start(int id) => GetHttpResult(await _contestService.Start(id));
        [HttpPut("end")]
        public async Task<IActionResult> End(int id) => GetHttpResult(await _contestService.End(id));
        [HttpPut("archive")]
        public async Task<IActionResult> Archive(int id) => GetHttpResult(await _contestService.Archive(id));
        [HttpPut("changestatus")]
        public async Task<IActionResult> ChangeStatus(int id) => GetHttpResult(await _contestService.ChangeStatus(id));
        [HttpPost("registeruser")]
        public async Task<IActionResult> RegisterUser(RegisterUserToContestRequest request) => GetHttpResult(await _contestService.RegisterUser(request));
        [HttpPost("registerteam")]
        public async Task<IActionResult> RegisterTeam(RegisterTeamToContestRequest request) => GetHttpResult(await _contestService.RegisterTeam(request));
        [HttpDelete("withdrawuser")]
        public async Task<IActionResult> WithdrawUser(RegisterUserToContestRequest request) => GetHttpResult(await _contestService.WithdrawUser(request));
        [HttpDelete("withdrawteam")]
        public async Task<IActionResult> WithDrawTeam(RegisterTeamToContestRequest request) => GetHttpResult(await _contestService.WithdrawTeam(request));
    }
}
