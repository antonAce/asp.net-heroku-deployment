using Microsoft.EntityFrameworkCore;

using AutoDock.Catalog.Domain.Core;

namespace AutoDock.Catalog.Data.EF.Context
{
    public class AutoDockContext : DbContext
    {
        public DbSet<Model> Models { get; set; }

        public AutoDockContext(DbContextOptions<AutoDockContext> options)
            : base(options) {}
    }
}