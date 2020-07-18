using System;

namespace VehicleCatalog.Data.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime ProductionEnd { get; set; }
        
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}