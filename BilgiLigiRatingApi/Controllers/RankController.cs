using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Services.Rank_;

namespace BilgiLigiRatingApi.Controllers
{
    [Route("api/rank")]
    [ApiController]
    public class RankController : BaseController
    {
        private readonly IRankService _service;
        public RankController(IRankService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=>GetHttpResult(await _service.GetAll());  
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActive()=>GetHttpResult(await _service.GetAllActive());  
        [HttpGet("getuserranks")]
        public async Task<IActionResult> GetUserRanks()=>GetHttpResult(await _service.GetUserRanks());  
        [HttpGet("getteamranks")]
        public async Task<IActionResult> GetTeamRanks()=>GetHttpResult(await _service.GetTeamRanks());  
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)=>GetHttpResult(await _service.GetById(id));  
        [HttpPost("add")]
        public async Task<IActionResult> Add(RankDto rank)=>GetHttpResult(await _service.Add(rank));  
        [HttpPut("update")]
        public async Task<IActionResult> Update(RankDto rank)=>GetHttpResult(await _service.Update(rank));  
        [HttpPut("changestatus")]
        public async Task<IActionResult> ChangeStatus(int id)=>GetHttpResult(await _service.ChangeStatus(id));  
        [HttpPut("archive")]
        public async Task<IActionResult> Archive(int id)=>GetHttpResult(await _service.Archive(id));  
    }
}
