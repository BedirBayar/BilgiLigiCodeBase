using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using BilgiLigiSecurityApi.DTOs;

namespace BilgiLigiSecurityApi.Controllers
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

        //protected IActionResult GetValidationErrorResult(ModelStateDictionary modelState)
        //{
        //    var response = new BaseResponse<List<string>>();
        //    var list=new List<string>();
        //    var errors = modelState.Select(x => x.Value.Errors)
        //                   .Where(y => y.Count > 0)
        //                   .ToList();
        //    foreach (var error in errors)
        //    {
        //        list.Add(error.ToString());
        //    }
        //    response.Data = list;
        //    response.Success = false;
        //    return BadRequest(response);
        //}
    }
}
