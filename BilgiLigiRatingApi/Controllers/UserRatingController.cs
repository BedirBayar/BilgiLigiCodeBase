using Microsoft.AspNetCore.Mvc;
using BilgiLigiRatingApi.DTOs;
using BilgiLigiRatingApi.Models;
using BilgiLigiRatingApi.Services.UserRating_;

namespace BilgiLigiRatingApi.Controllers
{
    [ApiController]
    [Route("api/userrating")]
    public class UserRatingController : BaseController
    {
        private readonly IUserRatingService _service;
        public UserRatingController(IUserRatingService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()=> GetHttpResult(await _service.GetAll());
        [HttpGet("getuserrating")]
        public async Task<IActionResult> GetUserRating(int userId)=> GetHttpResult(await _service.GetByUser(userId));
        [HttpGet("getbyratinginterval")]
        public async Task<IActionResult> GetByRatingInterval(int min, int max)=> GetHttpResult(await _service.GetByRatingInterval(min, max));
        [HttpGet("add")]
        public async Task<IActionResult> Add(UserRatingDto request)=> GetHttpResult(await _service.Add(request));
        [HttpGet("update")]
        public async Task<IActionResult> Update(UserRatingDto request) => GetHttpResult(await _service.Update(request));
        [HttpGet("delete")]
        public async Task<IActionResult> Delete(int userId)=> GetHttpResult(await _service.Delete(userId));
    }
}
