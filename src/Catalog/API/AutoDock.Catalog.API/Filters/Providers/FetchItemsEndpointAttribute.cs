using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

using AutoDock.Catalog.API.Filters.Implementation;

namespace AutoDock.Catalog.API.Filters.Providers
{
    public class FetchItemsEndpointAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
            serviceProvider.GetService<FetchItemsEndpointFilter>();

        public bool IsReusable => false;
    }
}