using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels.basicsetting
{
    public class LimitationDto
    {
        public Guid CompanyId { get; set; }
        public ICollection<LimitationDetailDto> Details { get; set; } = new List<LimitationDetailDto>();
    }

    public class LimitationDetailDto
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }

    public class LimitationListOutput
    {
        public LimitationDto[] Items { get; set; } = Array.Empty<LimitationDto>();
    }

    public class LimitationSaveInput : LimitationDto
    { }

    public class LimitationGetAmountInput
    {
        public Guid CompanyId { get; set; }
        public Guid[] ProductIds { get; set; } = Array.Empty<Guid>();
    }

    public class LimitationGetAmountOutput
    {
        public Dictionary<Guid, int> Items { get; set; } = new Dictionary<Guid, int>();
    }
}
