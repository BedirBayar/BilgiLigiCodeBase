﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Services.Award_;

namespace BilgiLigiRatingApi.Controllers
{
    [Route("api/award")]
    [ApiController]
    public class AwardController : BaseController
    {
        private readonly IAwardService _service;
        public AwardController(IAwardService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=>GetHttpResult(await _service.GetAll());
        [HttpGet("getallactive")]
        public async Task<IActionResult> GetAllActive()=>GetHttpResult(await _service.GetAllActive());
        [HttpPost("getbyidlist")]
        public async Task<IActionResult> GetByIdList(List<int> ids)=>GetHttpResult(await _service.GetByIdList(ids));
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)=>GetHttpResult(await _service.GetById(id));
        [HttpPost("add")]
        public async Task<IActionResult> Add(AwardDto request)=>GetHttpResult(await _service.Add(request));
        [HttpPut("update")]
        public async Task<IActionResult> Update(AwardDto request)=>GetHttpResult(await _service.Update(request));
        [HttpPut("changestatus")]
        public async Task<IActionResult> ChangeStatus(int id)=>GetHttpResult(await _service.ChangeStatus(id));
        [HttpPut("archive")]
        public async Task<IActionResult> Archive(int id)=>GetHttpResult(await _service.Archive(id));
    }
}
