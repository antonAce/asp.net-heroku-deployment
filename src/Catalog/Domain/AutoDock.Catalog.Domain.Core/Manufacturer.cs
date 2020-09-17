using System;
using System.Collections.Generic;

namespace AutoDock.Catalog.Domain.Core
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Foundation { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
