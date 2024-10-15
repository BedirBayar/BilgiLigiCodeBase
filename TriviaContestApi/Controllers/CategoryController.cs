using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaContestApi.DTOs;
using TriviaContestApi.Services.Category_;

namespace TriviaContestApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _service;

        public CategoryController (ICategoryService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=> GetHttpResult(  await _service.GetAll());    
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)=> GetHttpResult( await _service.GetById(id));    
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName(string name)=> GetHttpResult( await _service.GetByName(name));    
        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryDto request) => GetHttpResult( await _service.Add(request));    
        [HttpPut("update")]
        public async Task<IActionResult> Update(CategoryDto request) => GetHttpResult( await _service.Update(request));    
        [HttpPut("archive")]
        public async Task<IActionResult> Archive(int id) => GetHttpResult( await _service.Archive(id));    
        [HttpPut("archivebyname")]
        public async Task<IActionResult> ArchiveByName(string name) => GetHttpResult( await _service.ArchiveByName(name));    
        [HttpPut("changestatus")]
        public async Task<IActionResult> ChangeStatus(int id) => GetHttpResult( await _service.ChangeStatus(id));    
    }
}
