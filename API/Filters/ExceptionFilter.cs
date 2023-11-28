using API.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = new Error
            {
                StatusCode = HttpStatusCode.InternalServerError.ToString(),
                Message = $"Exception Filter: {context.Exception.Message}",
            };

            context.Result = new JsonResult(error) 
            { 
                StatusCode = (int) HttpStatusCode.InternalServerError 
            };
        }
    }
}
