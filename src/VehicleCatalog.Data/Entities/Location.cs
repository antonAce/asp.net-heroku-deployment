using System.Collections.Generic;

namespace VehicleCatalog.Data.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Manufacturer> Manufacturers { get; set; }
    }
}
