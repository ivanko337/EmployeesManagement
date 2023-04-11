using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeesManagement.Filters
{
    public class ExceptionsHandlerFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionsHandlerFilter> _logger;

        public ExceptionsHandlerFilter(ILogger<ExceptionsHandlerFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(
                context.Exception,
                "Unhandled exception on route {0}",
                context.HttpContext.Request.Path);

            context.Result = new EmptyResult();
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
