using System.ComponentModel;

namespace portal.ViewModels
{
    public class LimitationItem
    {
        public Guid CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public ICollection<LimitationDetailItem> Details { get; set; } = new List<LimitationDetailItem>();
    }

    public class LimitationDetailItem
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductAmount { get; set; }
    }
}
