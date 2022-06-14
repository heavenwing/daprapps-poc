using AppModels.godown;

namespace godown.DomainModels
{
    public class StorageOrder
    {
        public Guid Id { get; set; }
        public Guid ReceiptOrderId { get; set; }
        public Guid PuttorId { get; set; }
        public Guid WarehouseId { get; set; }
        public DateTimeOffset Putted { get; set; } = DateTimeOffset.UtcNow;
        public List<StorageOrderDetail> Details { get; set; } = new List<StorageOrderDetail>();

    }

    public struct StorageOrderDetail
    {
        public Guid ProductId { get; set; }
        public int ProductAmount { get; set; }
        public string BinlocationId { get; set; }
    }
}
