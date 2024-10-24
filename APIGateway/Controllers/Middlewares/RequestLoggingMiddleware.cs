using System.Text.Json;

namespace APIGateway.Controllers.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // İstek bilgilerini loglama
            _logger.LogInformation($"Incoming request: {JsonSerializer.Serialize(context.Request.Headers)}");

            // İsteği bir sonraki middleware'e ilet
            await _next(context);
        }
    }
}
