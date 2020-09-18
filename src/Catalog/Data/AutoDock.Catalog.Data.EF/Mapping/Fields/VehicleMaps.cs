using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using AutoDock.Catalog.Domain.Core;

namespace AutoDock.Catalog.Data.EF.Mapping.Fields
{
    public class VehicleMaps : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Vin);

            builder.Property(v => v.Vin)
                .ValueGeneratedNever();

            builder.Property(v => v.Price)
                .IsRequired();
            
            builder.Property(v => v.Year)
                .IsRequired()
                .HasDefaultValue(DateTime.UnixEpoch.Year);

            builder.Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(500);
            
            builder.Property(v => v.Fuel)
                .HasConversion<string>();

            builder.HasOne(v => v.Model)
                .WithMany(m => m.Vehicles)
                .HasForeignKey(v => v.ModelId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}