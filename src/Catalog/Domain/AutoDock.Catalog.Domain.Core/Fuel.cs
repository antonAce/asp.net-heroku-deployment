using System.Collections.Generic;

namespace AutoDock.Catalog.Domain.Core
{
    public class Fuel
    {
        public int Id { get; set; }
        public FuelType Type { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}