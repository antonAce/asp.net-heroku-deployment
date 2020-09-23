using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

using AutoDock.Catalog.API.Filters.Implementation;

namespace AutoDock.Catalog.API.Filters.Providers
{
    public sealed class BadRequestFilterAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
            serviceProvider.GetService<BadRequestExceptionFilter>();

        public bool IsReusable => false;
    }
}