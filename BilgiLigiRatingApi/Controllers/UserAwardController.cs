using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Models.UserModels;
using BilgiLigiRatingApi.Services.UserAward_;

namespace BilgiLigiRatingApi.Controllers
{
    [Route("api/useraward")]
    [ApiController]
    public class UserAwardController : BaseController
    {
        private readonly IUserAwardService _service;
        public UserAwardController(IUserAwardService service)
        {
            _service = service;
        }

        [HttpGet("gettbyuser")]
        public async Task<IActionResult> GetByUser(int id) => GetHttpResult(await _service.GetUserAwards(id));
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddUserAwardRequest request) => GetHttpResult(await _service.Add(request));
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(AddUserAwardRequest request) => GetHttpResult(await _service.Delete(request));
    }
}
