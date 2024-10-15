﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Controllers
{
    [Route("api/contest")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        public ContestController() { }

        [HttpGet("getall")]
        public async Task<BaseResponse<List<ContestDto>>> GetAll() =>  new BaseResponse<List<ContestDto>>();
    }
}
