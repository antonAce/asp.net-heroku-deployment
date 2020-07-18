using System;

namespace VehicleCatalog.Data.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Foundation { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }
    }
}