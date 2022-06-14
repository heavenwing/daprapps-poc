namespace inventory.DomainModels
{
    public class Binlocation
    {
        public string Id { get; set; }
        //public Guid WarehouseId { get; set; }
        public BinStatus Status { get; set; } = BinStatus.Empty;
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    }

    public enum BinStatus
    {
        Empty = 0,
        Available = 1,
        Full = 2,
    }
}
