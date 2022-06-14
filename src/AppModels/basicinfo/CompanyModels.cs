using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels.basicinfo
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class CompanyListOutput
    {
        public CompanyDto[] Items { get; set; } = Array.Empty<CompanyDto>();
    }
}
