using System.Collections.Generic;

namespace AutoDock.Catalog.Domain.Core
{
    public class Fuel
    {
        public FuelType Id { get; set; }
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}