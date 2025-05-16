using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogo.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("############# Action finalizada ###############");
            _logger.LogInformation($"#### {DateTime.Now.ToLongTimeString()} #######");
            _logger.LogInformation($"# StatusCode: {context.HttpContext.Response.StatusCode}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("############# Executando Action ###############");
            _logger.LogInformation($"#### {DateTime.Now.ToLongTimeString()} #######");
            _logger.LogInformation($"# ModelState: {context.ModelState.IsValid} ###");
        }
    }
}
