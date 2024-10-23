using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiContributionApi.DTOs;
using BilgiLigiContributionApi.Services;

namespace BilgiLigiContributionApi.Controllers
{
    [Route("api/draftquality")]
    [ApiController]
    public class DraftQualityController : BaseController
    {
        private readonly DraftQualityService _service;
        public DraftQualityController(DraftQualityService service)
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
        public async Task<IActionResult> Add(QuestionDraftQualityDto draft) => GetHttpResult(await _service.Add(draft));
        [HttpPut("update")]
        public async Task<IActionResult> Update(QuestionDraftQualityDto draft) => GetHttpResult(await _service.Update(draft));
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id) => GetHttpResult(await _service.Delete(id));
    }
}
