using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiContributionApi.DTOs;
using BilgiLigiContributionApi.Services;

namespace BilgiLigiContributionApi.Controllers
{
    [Route("api/questiondraft")]
    [ApiController]
    public class QuestionDraftController : BaseController
    {
        private readonly QuestionDraftService _service;
        public QuestionDraftController(QuestionDraftService service) { 
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=> GetHttpResult(await _service.GetAll());
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)=> GetHttpResult(await _service.GetById(id));
        [HttpGet("getbyquestion")]
        public async Task<IActionResult> GetByCategory(int categoryId)=> GetHttpResult(await _service.GetByCategory(categoryId));
        [HttpGet("getbycontributor")]
        public async Task<IActionResult> GetByContributor(int contributorId)=> GetHttpResult(await _service.GetByContributor(contributorId));
        [HttpPost("add")]
        public async Task<IActionResult> Add(QuestionDraftDto draft)=> GetHttpResult(await _service.Add(draft));
        [HttpPut("update")]
        public async Task<IActionResult> Update(QuestionDraftDto draft) => GetHttpResult(await _service.Update(draft));
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)=> GetHttpResult(await _service.Delete(id));
    }
}
