using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Library.API.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
               var  startTime = DateTimeOffset.Now;
               await _next(context);
               _logger.LogInformation($"Method:{context.Request.Method}: {context.Request.Path.Value} \n startTime:{startTime} \n endTime:{DateTimeOffset.Now}");
            
        }
    }


}
