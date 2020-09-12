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
        private readonly ILogger _logger;
        
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(JsonSerializer.Serialize(new {
                Date = DateTime.Now,
                Header = "ERROR",
                Origin = typeof(GlobalExceptionFilter).FullName,
                Message = context.Exception.Message,
                Trace = context.Exception.StackTrace
            }));

            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Content = "A server error has occurred!"
            };
            context.ExceptionHandled = true;
        }
    }
}