using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppModels.godown;

namespace AppModels.inventory
{
    public class WarehouseGetQuantitiesInput
    {
        public Guid CompanyId { get; set; }
        public Guid[] ProductIds { get; set; } = Array.Empty<Guid>();
    }

    public class WarehouseGetQuantitiesOutput
    {
        public Dictionary<Guid, int> Items { get; set; } = new Dictionary<Guid, int>();
    }

    public class WarehouseInitInput
    {
        public Guid CompanyId { get; set; }
        public string? WarehouseName { get; set; }
        public Guid[] ProductIds { get; set; } = Array.Empty<Guid>();
    }

    public class WarehouseInitOutput
    {
        public Guid Id { get; set; }
    }
}
