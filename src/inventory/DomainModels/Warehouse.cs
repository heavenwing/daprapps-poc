using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace inventory.DomainModels
{
    public class Warehouse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid CompanyId { get; set; } = Guid.Empty;
        public ICollection<Binlocation> Binlocations { get; set; } = new List<Binlocation>();

        public int SumQuantityByProductId(Guid productId)
        {
            var query = from bin in Binlocations
                        from stock in bin.Stocks
                        where stock.ProductId == productId
                        select stock.Quantity;
            return query.Sum();
        }
    }
}
