using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaContestApi.DTOs;
using TriviaContestApi.Services.Category_;

namespace TriviaContestApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController (ICategoryService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<BaseResponse<List<CategoryDto>>> GetAll()=> await _service.GetAll();    
        [HttpGet("getbyid")]
        public async Task<BaseResponse<CategoryDto>> GetById(int id)=> await _service.GetById(id);    
        [HttpGet("getbyname")]
        public async Task<BaseResponse<CategoryDto>> GetByName(string name)=> await _service.GetByName(name);    
        [HttpPost("add")]
        public async Task<BaseResponse<int>> Add(CategoryDto request) => await _service.Add(request);    
        [HttpPut("update")]
        public async Task<BaseResponse<bool>> Update(CategoryDto request) => await _service.Update(request);    
        [HttpPut("archive")]
        public async Task<BaseResponse<bool>> Archive(int id) => await _service.Archive(id);    
        [HttpPut("archivebyname")]
        public async Task<BaseResponse<bool>> ArchiveByName(string name) => await _service.ArchiveByName(name);    
        [HttpPut("changestatus")]
        public async Task<BaseResponse<bool>> ChangeStatus(int id) => await _service.ChangeStatus(id);    
    }
}
