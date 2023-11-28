using API.Contracts;
using System.Net;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var error = new Error
                {
                    StatusCode = context.Response.StatusCode.ToString(),
                    Message = ex.Message,
                };

                await context.Response.WriteAsync(error.ToString());
            }
        }
    }
}
