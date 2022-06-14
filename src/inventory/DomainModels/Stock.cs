using System.ComponentModel.DataAnnotations.Schema;

namespace inventory.DomainModels
{
    public class Stock
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
