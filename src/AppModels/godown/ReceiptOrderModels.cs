using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace AppModels.godown
{
    public class ReceiptOrderDto
    {
        public Guid ApplicationOrderId { get; set; }
        public Guid ReceiptorId { get; set; }
        public DateTimeOffset Deliveried { get; set; } = DateTimeOffset.Now;
        public List<ReceiptOrderDetailDto> Details { get; set; } = new List<ReceiptOrderDetailDto>();
    }

    public class ReceiptOrderDetailDto
    {
        public Guid ProductId { get; set; }
        public int ProductAmount { get; set; }
    }

    public class ReceiptOrderCreateInput : ReceiptOrderDto
    {
    }

    public class ReceiptOrderCreateOutput
    {
        public bool Success { get; set; }

        public string? Id { get; set; }
    }

    public class ReceiptOrderLoadOutput : ReceiptOrderDto
    { }
}
