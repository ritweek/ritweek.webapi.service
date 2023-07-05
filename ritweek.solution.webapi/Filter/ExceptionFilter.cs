using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ritweek.solution.webapi.common.Model;

namespace ritweek.solution.webapi.Filter
{
    public class ExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // No action needed before action execution
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.Result = new ObjectResult(new CustomResponse
                {
                    Title = "Error",
                    StatusCode = 500,
                    Message = context.Exception.Message ?? "An error occurred"
                })
                {
                    StatusCode = (int)System.Net.HttpStatusCode.InternalServerError
                };
                context.ExceptionHandled = true;
            }
        }
    }
}

