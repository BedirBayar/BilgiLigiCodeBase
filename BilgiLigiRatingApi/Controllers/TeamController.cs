using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Services.Team_;

namespace BilgiLigiRatingApi.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : BaseController
    {
        private readonly ITeamService _service;
        public TeamController(ITeamService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult>GetAll() =>GetHttpResult(await _service.GetAll());
        [HttpGet("getallactive")]
        public async Task<IActionResult>GetAllActive() =>GetHttpResult(await _service.GetAllActive());
        [HttpGet("getbyid")]
        public async Task<IActionResult>GetById(int id) =>GetHttpResult(await _service.GetById(id));
        [HttpGet("getbyname")]
        public async Task<IActionResult>GetByName(string name) =>GetHttpResult(await _service.GetByName(name));
        [HttpPost("add")]
        public async Task<IActionResult>Add(TeamDto request) =>GetHttpResult(await _service.Add(request));
        [HttpPut("update")]
        public async Task<IActionResult>Update(TeamDto request) =>GetHttpResult(await _service.Update(request));
        [HttpPut("changestatus")]
        public async Task<IActionResult>ChangeStatus(int id) =>GetHttpResult(await _service.ChangeStatus(id));
        [HttpPut("archive")]
        public async Task<IActionResult>Archive(int id) =>GetHttpResult(await _service.Archive(id));
        [HttpPut("banunban")]
        public async Task<IActionResult>BanUnban(BanRequest request) =>GetHttpResult(await _service.BanUnban(request));
    }
}
