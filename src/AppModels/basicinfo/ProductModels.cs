using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels.basicinfo
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsExempted { get; set; }
    }

    public class ProductListOutput
    {
        public ProductDto[] Items { get; set; } = Array.Empty<ProductDto>();
    }

    public class ProductAddInput : ProductDto
    {
    }

    public class ProductUpdateInput : ProductDto
    {
    }
}
