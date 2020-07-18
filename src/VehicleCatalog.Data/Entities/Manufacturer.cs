using System;
using System.Collections.Generic;

namespace VehicleCatalog.Data.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Foundation { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }
        
        public ICollection<Model> Models { get; set; }
    }
}
