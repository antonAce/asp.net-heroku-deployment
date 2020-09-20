using AutoDock.Catalog.Data.EF.Mapping.Data;
using Microsoft.EntityFrameworkCore;

using AutoDock.Catalog.Domain.Core;
using AutoDock.Catalog.Data.EF.Mapping.Fields;

namespace AutoDock.Catalog.Data.EF.Context
{
    public class AutoDockContext : DbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public AutoDockContext(DbContextOptions<AutoDockContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModelMaps());
            modelBuilder.ApplyConfiguration(new ManufacturerMaps());
            modelBuilder.ApplyConfiguration(new VehicleMaps());
            modelBuilder.ApplyConfiguration(new FuelMaps());
            
            modelBuilder.ApplyConfiguration(new FuelData());
        }
    }
}