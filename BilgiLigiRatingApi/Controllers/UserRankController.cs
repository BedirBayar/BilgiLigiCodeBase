using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Models.RankModels;
using BilgiLigiRatingApi.Models.UserModels;
using BilgiLigiRatingApi.Services.UserRank_;

namespace BilgiLigiRatingApi.Controllers
{
    [Route("api/userrank")]
    [ApiController]
    public class UserRankController : BaseController
    {
        private readonly IUserRankService _service;
        public UserRankController(IUserRankService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=>GetHttpResult(await _service.GetAll());
        [HttpGet("getbyrank")]
        public async Task<IActionResult> GetByRank(int rank)=>GetHttpResult(await _service.GetByRank(rank));
        [HttpGet("getbyuser")]
        public async Task<IActionResult> GetByUser(int userId)=>GetHttpResult(await _service.GetByUser(userId));
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddUserRankRequest request) =>GetHttpResult(await _service.Add(request));
        [HttpPut("update")]
        public async Task<IActionResult> Update(AddUserRankRequest request) =>GetHttpResult(await _service.Update(request));
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int request) =>GetHttpResult(await _service.Delete(request));
    }
}

