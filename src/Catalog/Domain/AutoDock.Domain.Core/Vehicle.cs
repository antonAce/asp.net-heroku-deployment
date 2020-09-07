using System;

namespace AutoDock.Domain.Core
{
    public class Vehicle
    {
        public string Vin { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }

        public string Description { get; set; }
        public Fuel Fuel { get; set; }

        public int? ModelId { get; set; }
        public Model Model { get; set; }
    }
}
