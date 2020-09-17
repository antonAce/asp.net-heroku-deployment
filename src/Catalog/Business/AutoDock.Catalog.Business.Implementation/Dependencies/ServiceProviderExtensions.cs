using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

using AutoDock.Catalog.Business.Interfaces.Services;
using AutoDock.Catalog.Business.Implementation.Services;
using AutoDock.Catalog.Business.Implementation.Mapping;

namespace AutoDock.Catalog.Business.Implementation.Dependencies
{
    public static class ServiceProviderExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            var mapConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<ModelProfile>();
                config.AddProfile<ManufacturerProfile>();
            });

            services.AddScoped(mapper => mapConfig.CreateMapper());
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
        }
    }
}
