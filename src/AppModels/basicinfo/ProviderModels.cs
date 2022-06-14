using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels.basicinfo
{
    public class ProviderDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class ProviderListOutput
    {
        public ProviderDto[] Items { get; set; } = Array.Empty<ProviderDto>();
    }
}
