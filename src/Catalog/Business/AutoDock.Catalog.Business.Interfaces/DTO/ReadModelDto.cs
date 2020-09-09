using System;

namespace AutoDock.Catalog.Business.Interfaces.DTO
{
    public class ReadModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductionStart { get; set; }
        public DateTime ProductionEnd { get; set; }
    }
}