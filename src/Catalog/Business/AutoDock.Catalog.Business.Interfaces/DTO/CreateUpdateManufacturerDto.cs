using System;

namespace AutoDock.Catalog.Business.Interfaces.DTO
{
    public class CreateUpdateManufacturerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Foundation { get; set; }
    }
}