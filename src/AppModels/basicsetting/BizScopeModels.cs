using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels.basicsetting
{
    public class BizScopeDto
    {
        public Guid BizEntityId { get; set; }
        public Guid[] ProductIds { get; set; } = Array.Empty<Guid>();
    }

    public class BizScopeListOutput
    {
        public BizScopeDto[] Items { get; set; } = Array.Empty<BizScopeDto>();
    }

    public class BizScopeSaveInput : BizScopeDto
    { }

    public class BizScopeGetAllowableInput
    {
        public Guid CompanyId { get; set; }
        public Guid ProviderId { get; set; }
    }

    public class BizScopeGetAllowableOutput
    {
        public Guid[] Items { get; set; } = Array.Empty<Guid>();
    }
}
