using Microsoft.AspNetCore.Mvc;
using TriviaRatingApi.Models;

namespace TriviaRatingApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult GetHttpResult<T>(BaseResponse<T> response)
        {
            if (response.Success)
                return Ok(response);

            if (response.Error != null)
            {
                switch (response.Error.Code)
                {
                    case "400":
                        return BadRequest(response);
                    case "404":
                        return NotFound(response);
                    case "500":
                        return StatusCode(500, response);
                    default:
                        return StatusCode(500, response); 
                }
            }

            return StatusCode(500, response);
        }
    }
}
