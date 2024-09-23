using Microsoft.AspNetCore.Mvc;

namespace TriviaSecurityApi.DTOs
{
 
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public ErrorResponse? Error { get; set; }
        public BaseResponse() { }
        public BaseResponse(ErrorResponse error)
        {
            Success = false;
            Error = error;
            Data = default(T);
        }
        public BaseResponse(T data) {
            Success = true;
            Data= data;
        }

    }
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
