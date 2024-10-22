using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaContestApi.DTOs;
using TriviaContestApi.Services.ContestType_;

namespace TriviaContestApi.Controllers
{
    [Route("api/contesttype")]
    [ApiController]
    public class ContestTypeController : BaseController
    {
        private readonly IContestTypeService _service;
        public ContestTypeController(IContestTypeService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => GetHttpResult(await _service.GetAll());
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActive() => GetHttpResult(await _service.GetAllActive());
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id) => GetHttpResult(await _service.GetById(id));
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName(string name) => GetHttpResult(await _service.GetByName(name));
        [HttpPost("add")]
        public async Task<IActionResult> Add(ContestTypeDto dto) => GetHttpResult(await _service.Add(dto));
        [HttpPut("update")]
        public async Task<IActionResult> Update(ContestTypeDto dto) => GetHttpResult(await _service.Update(dto));
        [HttpPut("archive")]
        public async Task<IActionResult> Archive(int id) => GetHttpResult(await _service.Archive(id));
        [HttpPut("changestatus")]
        public async Task<IActionResult> ChangeStatus(int id) => GetHttpResult(await _service.ChangeStatus(id));
    }
}
