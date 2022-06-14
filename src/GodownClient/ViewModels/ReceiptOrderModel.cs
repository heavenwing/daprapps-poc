using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodownClient.ViewModels
{
    public class ReceiptOrderModel
    {
        public Guid ApplicationOrderId { get; set; }

        public Guid ReceiptorId { get; set; } = Guid.NewGuid();

        public List<ProductModel> Details { get; set; } = new List<ProductModel>();
    }
}
