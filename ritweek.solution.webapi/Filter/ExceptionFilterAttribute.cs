using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Diagnostics.CodeAnalysis;

namespace ritweek.solution.webapi.Filter
{
    [ExcludeFromCodeCoverage]
    public class ExceptionFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Custom error handling logic
            // You can log the exception or customize the error response as per your requirements
            context.Result = new ObjectResult("An error occurred.")
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}

