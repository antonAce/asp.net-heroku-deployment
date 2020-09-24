using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoDock.Catalog.API.Filters.Implementation
{
    public class FetchItemsEndpointFilter : IActionFilter
    {
        private ILogger Logger { get; }

        private readonly ICollection<string> FetchingArguments = new[] { "page", "items" };

        public FetchItemsEndpointFilter(ILogger<FetchItemsEndpointFilter> logger)
        {
            Logger = logger;
        }
        
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Query.Keys.SequenceEqual(FetchingArguments)) return;

            var message = new
            {
                Origin = nameof(FetchItemsEndpointFilter),
                Message = "Pagination properties are not defined",
                Sender = context.HttpContext.Connection.RemoteIpAddress.ToString()
            };

            Logger.LogInformation("{message}", message);

            context.Result = new ObjectResult("Pagination properties are not defined") { StatusCode = 400 };
        }
    }
}