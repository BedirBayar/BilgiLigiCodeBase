using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaContestApi.DTOs;
using TriviaContestApi.Services.Question_;

namespace TriviaContestApi.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _service;
        public QuestionController(IQuestionService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll() => GetHttpResult(await _service.GetAll());
        [HttpGet("getbycategory")]
        public async Task<IActionResult> GetByCategory(int id) => GetHttpResult(await _service.GetByCategory(id));
        [HttpGet("getbydifficulty")]
        public async Task<IActionResult> GetByDifficulty(int easy, int hard) => GetHttpResult(await _service.GetByDifficulty(easy, hard));
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id) => GetHttpResult(await _service.GetById(id));
        [HttpPost("add")]
        public async Task<IActionResult> Add(QuestionDto question) => GetHttpResult(await _service.Add(question));
        [HttpPost("addrange")]
        public async Task<IActionResult> AddRange(List<QuestionDto> questions) => GetHttpResult(await _service.AddRange(questions));
        [HttpPut("update")]
        public async Task<IActionResult> Update(QuestionDto question) => GetHttpResult(await _service.Update(question));
        [HttpPut("changestatus")]
        public async Task<IActionResult> ChangeStatus(int id) => GetHttpResult(await _service.ChangeStatus(id));
        [HttpPut("archive")]
        public async Task<IActionResult> Archive(int id) => GetHttpResult(await _service.Archive(id));
    }
}
