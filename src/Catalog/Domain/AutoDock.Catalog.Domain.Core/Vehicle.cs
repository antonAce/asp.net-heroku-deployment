using System;

namespace AutoDock.Catalog.Domain.Core
{
    public class Vehicle
    {
        public string Vin { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }

        public string Description { get; set; }
        
        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }

        public int? ModelId { get; set; }
        public Model Model { get; set; }
    }
}
