using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using AutoDock.Catalog.Domain.Core;

namespace AutoDock.Catalog.Data.EF.Mapping.Fields
{
    public class ModelMaps : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(m => m.ProductionStart)
                .IsRequired();
            
            builder.Property(m => m.ProductionEnd)
                .IsRequired();
            
            builder.Property(m => m.ManufacturerId)
                .IsRequired();

            builder.HasOne(m => m.Manufacturer)
                .WithMany(ma => ma.Models)
                .HasForeignKey(m => m.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(m => m.Name);
        }
    }
}