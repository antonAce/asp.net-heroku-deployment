using System;

namespace VehicleCatalog.Business.DTO
{
    public class ModelPayloadDTO
    {
        public string Name { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime ProductionEnd { get; set; }
    }
}