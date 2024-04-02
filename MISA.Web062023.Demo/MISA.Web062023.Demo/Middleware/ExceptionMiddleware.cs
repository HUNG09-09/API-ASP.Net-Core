using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MISA.Web062023.Demo.Domain;
using System;

namespace MISA.Web062023.Demo.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Console.WriteLine(exception);
            context.Response.ContentType = "application/json";

            if (exception is NotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(
                    text: new BaseException()
                    {
                        ErrorCode = ((NotFoundException)exception).ErrorCode,
                        UserMessage = "Khong tim thay",
                        DevMessage = exception.Message,
                        TraceId = context.TraceIdentifier,
                        MoreInfo = exception.HelpLink
                    }.ToString() ?? ""
                );
            }
            else
            {
                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(
                   text: new BaseException()
                   {
                       ErrorCode = context.Response.StatusCode,
                       UserMessage = "Lỗi hệ thống",
#if DEBUG
                       DevMessage = exception.Message,
#else
                       DevMessage = "",
#endif
                       TraceId = context.TraceIdentifier,
                       MoreInfo = exception.HelpLink
                   }.ToString() ?? ""
                );
            }
        }
    }
}
