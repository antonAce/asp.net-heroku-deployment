using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using AutoDock.Catalog.Domain.Core;

namespace AutoDock.Catalog.Data.EF.Mapping.Fields
{
    public class FuelMaps : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.Property(f => f.Type)
                .HasConversion<string>();
        }
    }
}