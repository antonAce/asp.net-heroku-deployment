using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using IUoW = AutoDock.Catalog.Domain.Interfaces.UnitOfWork.IUnitOfWork;
using AutoDock.Catalog.Domain.Interfaces.Repositories;

using AutoDock.Catalog.Data.EF.Context;
using AutoDock.Catalog.Data.EF.Repositories;
using UoW = AutoDock.Catalog.Data.EF.UnitOfWork.UnitOfWork;

namespace AutoDock.Catalog.Data.EF.Dependencies
{
    public static class DataProviderExtensions
    {
        public static void AddPostgreStorage(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AutoDockContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUoW, UoW>();
            services.AddScoped<IModelRepository, ModelRepository>();
        }
    }
}