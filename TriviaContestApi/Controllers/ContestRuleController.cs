using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaContestApi.DTOs;
using TriviaContestApi.Services.ContestRule_;
using TriviaContestApi.Services.ContestType_;

namespace TriviaContestApi.Controllers
{
    [Route("api/contestrule")]
    [ApiController]
    public class ContestRuleController : BaseController
    {
        private readonly IContestRuleService _service;
        public ContestRuleController(IContestRuleService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => GetHttpResult(await _service.GetAll());
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActive() => GetHttpResult(await _service.GetAllActive());
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id) => GetHttpResult(await _service.GetById(id));
        [HttpGet("getbycontesttype")]
        public async Task<IActionResult> GetByContestType(int contestTypeId) => GetHttpResult(await _service.GetByContestType(contestTypeId));
        [HttpPost("add")]
        public async Task<IActionResult> Add(ContestRuleDto dto) => GetHttpResult(await _service.Add(dto));
        [HttpPut("update")]
        public async Task<IActionResult> Update(ContestRuleDto dto) => GetHttpResult(await _service.Update(dto));
        [HttpPut("archive")]
        public async Task<IActionResult> Archive(int id) => GetHttpResult(await _service.Archive(id));
        [HttpPut("changestatus")]
        public async Task<IActionResult> ChangeStatus(int id) => GetHttpResult(await _service.ChangeStatus(id));
    }
}
