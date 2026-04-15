using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.MiddlewareAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace MyVinCafeNewApi.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            //return _next(httpContext);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = StatusCodes.Status500InternalServerError;
            var message = "Ada kesalahan dalam sistem internal";

            if (exception is KeyNotFoundException)
            {
                statusCode = StatusCodes.Status404NotFound;
                message = exception.Message;
            }

            else if (exception is ArgumentException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                message = exception.Message;
            }

            context.Response.StatusCode = statusCode;

            var result = new
            {
                sukses = false,
                error = message,
                details = exception.Message
            };
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
