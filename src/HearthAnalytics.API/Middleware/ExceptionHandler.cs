using HearthAnalytics.API.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HearthAnalytics.API.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;

        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;

            ErrorDto errorDto = new ErrorDto()
            {
                ExceptionMessage = exception.Message,
                StackTrace = exception.StackTrace,
                InnerExceptionMessage = exception.InnerException?.Message,
                ExceptionType = exception.GetType().FullName,
                Source = exception.Source
            };

            await WriteExceptionAsync(context, errorDto).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, ErrorDto errorDto)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await response.WriteAsync(errorDto.ToString()).ConfigureAwait(false);
        }
    }
}
