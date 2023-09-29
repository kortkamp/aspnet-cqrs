using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Syslog.Api.Contracts;

namespace Syslog.Api.Filters
{
    public class ApiResponseFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // This method is executed before the action method.
            // You can perform any pre-processing here if needed.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // This method is executed after the action method.
            // Modify the response structure here.
            if (context.Result is ObjectResult objectResult)
            {
                var value = objectResult.Value;
                var response = new AppResponse<object>(value);

                context.Result = new ObjectResult(response)
                {
                    StatusCode = objectResult.StatusCode,
                    DeclaredType = objectResult.DeclaredType,
                    ContentTypes = objectResult.ContentTypes,
                    Formatters = objectResult.Formatters,
                };
            }
        }
    }
}