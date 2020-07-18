using System;

namespace VehicleCatalog.Business.DTO
{
    public class ModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime ProductionEnd { get; set; }
    }
}