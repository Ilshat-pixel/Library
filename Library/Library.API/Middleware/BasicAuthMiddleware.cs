using Library.API.Exceprions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
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
            var authorization = context.Request.Headers["Authorization"];
            if (authorization.Count == 0)
            {
                throw new HttpStatusException(HttpStatusCode.Unauthorized, "You should pass Authorization header");
            }
            var credentials = authorization.ToString().Split(':');
            try
            {
                var username = credentials[0] ?? "";
                var password = credentials[1] ?? "";
                if (username != "admin" && password != "admin")
                {
                    throw new HttpStatusException(HttpStatusCode.BadRequest, "Invalid authorization login or password");
                }
            }
            catch (Exception)
            {

                throw new HttpStatusException(HttpStatusCode.BadRequest, "Cannot parse authorization header");
            }
            await _next.Invoke(context);
        }
    }
}
