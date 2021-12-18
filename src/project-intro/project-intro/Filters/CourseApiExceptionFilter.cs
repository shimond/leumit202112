using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using project_intro.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Filters
{
    public interface ICourseApiExceptionFilter : IActionFilter { }
    public class CourseApiExceptionFilter : ICourseApiExceptionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception != null && context.Exception is CourseApiException)
            {
                var ex = context.Exception as CourseApiException;
                switch (ex.ApiExceptionType)
                {
                    case ApiExceptionType.NotFound:
                        context.Result = new NotFoundResult();
                        context.ExceptionHandled = true;
                        break;
                    case ApiExceptionType.Conflict:
                        context.Result = new ConflictResult();
                        context.ExceptionHandled = true;
                        break;
                }
            }
        }

    }

    class MyFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // OnActionExecuting
            var contextAfter  = await next();
            // OnActionExecuted
            if (contextAfter.Exception != null && contextAfter.Exception is CourseApiException)
            {
                var ex = contextAfter.Exception as CourseApiException;
                switch (ex.ApiExceptionType)
                {
                    case ApiExceptionType.NotFound:
                        contextAfter.Result = new NotFoundResult();
                        contextAfter.ExceptionHandled = true;
                        break;
                    case ApiExceptionType.Conflict:
                        contextAfter.Result = new ConflictResult();
                        contextAfter.ExceptionHandled = true;
                        break;
                }
            }
        }
    }
}
