namespace godown.DomainModels
{
    public class ReceiptOrder
    {
        public Guid Id { get; set; }
        public Guid ApplicationOrderId { get; set; }
        public Guid ReceiptorId { get; set; }
        public DateTimeOffset Deliveried { get; set; } = DateTimeOffset.Now;
        public ICollection<ReceiptOrderDetail> Details { get; set; } = new List<ReceiptOrderDetail>();
    }

    public struct ReceiptOrderDetail
    {
        public Guid ProductId { get; set; }
        public int ProductAmount { get; set; }
    }
}
