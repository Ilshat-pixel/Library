using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Library.API.Middleware
{
    /// <summary>
    /// 2.2.4 - middlerware которая запрещает вызывать методы без хэдера
    /// </summary>
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string authorization = context.Request.Headers["Authorization"];
            if (authorization != null)
            {
                if (authorization == "Basic admin:admin")
                {
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                return;
            }
        }
    }
}
