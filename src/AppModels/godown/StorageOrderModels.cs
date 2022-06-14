using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels.godown
{
    public class StorageOrderDto
    {
        public Guid ReceiptOrderId { get; set; }
        public Guid PuttorId { get; set; } = Guid.NewGuid();
        public DateTimeOffset Putted { get; set; } = DateTimeOffset.UtcNow;
        public Guid WarehouseId { get; set; }
        public List<StorageOrderDetailDto> Details { get; set; } = new List<StorageOrderDetailDto>();
    }

    public class StorageOrderDetailDto
    {
        public Guid ProductId { get; set; }
        public int ProductAmount { get; set; }
        public string BinlocationId { get; set; }
    }

    public class StorageOrderCreateInput : StorageOrderDto
    {
    }

    public class StorageOrderCreateOutput
    {
        public bool Success { get; set; }

        public string? Id { get; set; }
    }

    public class StorageOrderLoadOutput : StorageOrderDto
    { }

    public class PutStorageEvent
    {
        public Guid StorageOrderId { get; set; }
        public Guid WarehouseId { get; set; }
        public List<StorageOrderDetailDto> Details { get; set; } = new List<StorageOrderDetailDto>();
    }
}
