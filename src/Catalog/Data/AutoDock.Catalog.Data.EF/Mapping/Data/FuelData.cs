using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using AutoDock.Catalog.Domain.Core;

namespace AutoDock.Catalog.Data.EF.Mapping.Data
{
    public class FuelData : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.HasData(
                    Enum.GetValues(typeof(FuelType))
                        .Cast<FuelType>()
                        .Select(e => new Fuel
                        {
                            Id = e,
                            Name = e.ToString()
                        })
                );
        }
    }
}