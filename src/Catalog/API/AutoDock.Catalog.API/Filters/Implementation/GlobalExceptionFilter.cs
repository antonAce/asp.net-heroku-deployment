using System;
using System.Net;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoDock.Catalog.API.Filters.Implementation
{
    public sealed class GlobalExceptionFilter : IExceptionFilter
    {
        public ILogger Logger { get; }
        
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            Logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var message = new
            {
                typeof(GlobalExceptionFilter).FullName,
                context.Exception.Message,
                context.Exception.StackTrace
            };

            Logger.LogError("{message}", message);

            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Content = "A server error has occurred!"
            };
            context.ExceptionHandled = true;
        }
    }
}