using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaContributionApi.DTOs;
using TriviaContributionApi.Services;

namespace TriviaContributionApi.Controllers
{
    [Route("api/usercontributionrating")]
    [ApiController]
    public class UserContributionRatingController : BaseController
    {
        private readonly UserContributionRatingService _service;
        public UserContributionRatingController(UserContributionRatingService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => GetHttpResult(await _service.GetAll());
        [HttpGet("gettopn")]
        public async Task<IActionResult> GetById(int n) => GetHttpResult(await _service.GetTopN(n));
        [HttpGet("getbyratinginterval")]
        public async Task<IActionResult> GetByRatingInterval(int min, int max) => GetHttpResult(await _service.GetByRatingInterval(min, max));
        [HttpGet("getbyuser")]
        public async Task<IActionResult> GetByUser(int userId) => GetHttpResult(await _service.GetByUser(userId));
        [HttpPost("add")]
        public async Task<IActionResult> Add(UserContributionRatingDto ucr) => GetHttpResult(await _service.Add(ucr));
        [HttpPut("update")]
        public async Task<IActionResult> Update(UserContributionRatingDto ucr) => GetHttpResult(await _service.Update(ucr));
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id) => GetHttpResult(await _service.Delete(id));
    }
}
