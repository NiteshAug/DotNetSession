using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApplication4.ActionFilters
{
    public class ActionFilterImpl : IActionFilter
    {
        private readonly ILogger _logger;
        private readonly string _name;

        public ActionFilterImpl(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ActionFilterImpl>();            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {            
            _logger.LogInformation("Calling OnActionExecuted: ", context.ActionDescriptor);
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var data = context.HttpContext.Request.Headers;
            _logger.LogInformation("Calling OnActionExecuting: ", context.ActionArguments);
        }
    }
}
