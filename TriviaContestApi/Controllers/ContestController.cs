using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaContestApi.DTOs;
using TriviaContestApi.Services.Contest_;

namespace TriviaContestApi.Controllers
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
    }
}
