using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaContributionApi.DTOs;
using TriviaContributionApi.Services;

namespace TriviaContributionApi.Controllers
{
    [Route("api/draftdifficulty")]
    [ApiController]
    public class DraftDifficultyController : BaseController
    {
        private readonly DraftDifficultyService _service;
        public DraftDifficultyController(DraftDifficultyService service)
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
        public async Task<IActionResult> Add(QuestionDraftDifficultyDto draft) => GetHttpResult(await _service.Add(draft));
        [HttpPut("update")]
        public async Task<IActionResult> Update(QuestionDraftDifficultyDto draft) => GetHttpResult(await _service.Update(draft));
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id) => GetHttpResult(await _service.Delete(id));
    }
}
