using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels.godown
{
    public class ApplicationOrderDto
    {
        public Guid CompanyId { get; set; }
        public Guid BuyerId { get; set; }
        public Guid ProviderId { get; set; }
        public List<ApplicationOrderDetailDto> Details { get; set; } = new List<ApplicationOrderDetailDto>();
    }

    public class ApplicationOrderDetailDto
    {
        public Guid ProductId { get; set; }
        public int ProductAmount { get; set; }
    }

    public class ApplicationOrderCreateInput : ApplicationOrderDto
    { }

    public class ApplicationOrderCreateOutput
    {
        public bool Success { get; set; }

        public string? Id { get; set; }
    }

    public class ApplicationOrderLoadOutput : ApplicationOrderDto
    { 
        public bool IsComplete { get; set; }
    }

    public class ApplicationWorkflowInput
    {
        public string? Id { get; set; }
    }

    public class ApplicationOrderCheckLimitationOutput
    {
        public bool Exceed { get; set; }
    }

    public class ApplicationOrderIsExceededDto
    {
        public Dictionary<Guid, int> LimitAmounts { get; set; } = new Dictionary<Guid, int>();
        public Dictionary<Guid, int> InventoryQuantities { get; set; } = new Dictionary<Guid, int>();
    }
}
