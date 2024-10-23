using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiContributionApi.DTOs;
using BilgiLigiContributionApi.Services;

namespace BilgiLigiContributionApi.Controllers
{
    [Route("api/questiondifficulty")]
    [ApiController]
    public class QuestionDifficultyController : BaseController
    {
        private readonly QuestionDifficultyService _service;
        public QuestionDifficultyController(QuestionDifficultyService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => GetHttpResult(await _service.GetAll());
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id) => GetHttpResult(await _service.GetById(id));
        [HttpGet("getbyquestion")]
        public async Task<IActionResult> GetByQuestion(int questionId) => GetHttpResult(await _service.GetByQuestion(questionId));
        [HttpGet("getbycontributor")]
        public async Task<IActionResult> GetByContributor(int contributorId) => GetHttpResult(await _service.GetByUser(contributorId));
        [HttpPost("add")]
        public async Task<IActionResult> Add(QuestionDifficultyDto qd) => GetHttpResult(await _service.Add(qd));
        [HttpPut("update")]
        public async Task<IActionResult> Update(QuestionDifficultyDto qd) => GetHttpResult(await _service.Update(qd));
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id) => GetHttpResult(await _service.Delete(id));
    }
}
