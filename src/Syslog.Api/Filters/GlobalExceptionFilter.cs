using System.Net;

using Microsoft.AspNetCore.Mvc.Filters;

using Syslog.Api.ApplicationExceptions;
using Syslog.Api.Contracts;

namespace Syslog.API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            HttpStatusCode statusCode;

            switch (exception)
            {
                case InvalidOperationException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case ArgumentNullException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case EntityNotFoundException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    _logger.LogError($"GlobalExceptionFilter: Error in {context.ActionDescriptor.DisplayName}.{exception.Message}. Stack Trace: {exception.StackTrace}");
                    break;
            }

            var error = new Error()
            {
                StatusCode = (int)statusCode,
                Message = exception.Message,
            };

            context.Result = error.ToJsonResult();
        }
    }
}