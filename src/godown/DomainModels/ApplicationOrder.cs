using static Grpc.Core.Metadata;

namespace godown.DomainModels
{
    public class ApplicationOrder
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid BuyerId { get; set; }
        public Guid ProviderId { get; set; }
        public ICollection<ApplicationOrderDetail> Details { get; set; } = new List<ApplicationOrderDetail>();
        public bool IsComplete { get; set; }

        public void Complete()
        {
            IsComplete = true;
        }

        public bool IfExceeded(Dictionary<Guid, int> inventoryQuantities, Dictionary<Guid, int> limitAmounts)
        {
            bool exceeded = false;
            foreach (var d in Details)
            {
                var limitAmount = limitAmounts[d.ProductId];
                if (limitAmount == -1) continue;
                if (d.ProductAmount + inventoryQuantities[d.ProductId] > limitAmount)
                {
                    exceeded = true;
                    break;
                }
            }
            return exceeded;
        }
    }

    public struct ApplicationOrderDetail
    {
        public Guid ProductId { get; set; }
        public int ProductAmount { get; set; }
    }
}
