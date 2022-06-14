using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppModels.basicinfo;

namespace GodownClient.ViewModels
{
    public class ApplicationOrderModel
    {
        public ProductDto[] AllProducts { get; set; } = Array.Empty<ProductDto>();

        public List<BasicInfoModel> ProductList { get; set; } = new List<BasicInfoModel>()
        {
            new BasicInfoModel() {Id=Guid.Empty,Name="Select ..."},
        };
        public List<BasicInfoModel> ProviderList { get; set; } = new List<BasicInfoModel>()
        {
            new BasicInfoModel() {Id=Guid.Empty,Name="Select ..."},
        };
        public List<BasicInfoModel> CompanyList { get; set; } = new List<BasicInfoModel>()
        {
            new BasicInfoModel() {Id=Guid.Empty,Name="Select ..."},
        };
        public List<ProductModel> Details { get; set; } = new List<ProductModel>();

        public Guid ProviderId { get; set; } = Guid.NewGuid();
        public Guid CompanyId { get; set; } = Guid.NewGuid();

        public bool IsComplete { get; set; }
    }

    //public class ProviderModel
    //{
    //    public Guid Id { get; set; }
    //    public string? Name { get; set; }
    //}
}
