using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels.Common
{
    public class GetNamesInput
    {
        public Guid[]? Ids { get; set; }
    }

    public class GetNamesOutput
    {
        public Dictionary<Guid, string> Items { get; set; } = new Dictionary<Guid, string>();
    }
}
