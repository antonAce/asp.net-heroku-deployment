using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using AutoDock.Catalog.Domain.Core;

namespace AutoDock.Catalog.Data.EF.Mapping.Fields
{
    public class ManufacturerMaps : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.Property(ma => ma.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ma => ma.Foundation)
                .IsRequired();
        }
    }
}