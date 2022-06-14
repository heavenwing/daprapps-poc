using System.Xml.Linq;
using portal.ViewModels;

namespace portal.GatewayServices
{
    public class MockData
    {
        static Guid prodcutId1 = Guid.NewGuid();
        static Guid prodcutId2 = Guid.NewGuid();
        static Guid prodcutId3 = Guid.NewGuid();
        const string productName1 = "Product 1";
        const string productName2 = "Product 2";
        const string productName3 = "Product 3";

        static Guid companyId1 = Guid.NewGuid();
        static Guid companyId2 = Guid.NewGuid();
        static Guid providerId1 = Guid.NewGuid();
        const string companyName1 = "Company A";
        const string companyName2 = "Company B";
        const string providerName1 = "Provider A";

        public static List<ProductItem> ProductList => new List<ProductItem>
            {
                new ProductItem()
                {
                    Id = prodcutId1,
                    Name = productName1,
                },
                new ProductItem()
                {
                    Id = prodcutId2,
                    Name = productName2,
                },
                new ProductItem()
                {
                    Id = prodcutId3,
                    Name = productName3,
                    IsExempted = true,
                },
            };

        public static List<BizEntityItem> BizEntityList => new List<BizEntityItem>
            {
                new BizEntityItem()
                {
                    Id =companyId1,
                    Name =companyName1,
                    Scopes = new[]
                    {
                        new BizScopeItem
                        {
                            ProductId=prodcutId1,
                            ProductName=productName1,
                        },
                    }
                },
                new BizEntityItem()
                {
                    Id =providerId1,
                    Name =providerName1,
                    Scopes = new[]
                    {
                        new BizScopeItem
                        {
                            ProductId=prodcutId2,
                            ProductName=productName2,
                        },
                    }
                }
            };

        public static List<LimitationItem> CompanyList => new List<LimitationItem>
            {
                new LimitationItem()
                {
                    CompanyId =companyId1,
                    CompanyName =companyName2,
                    Details = new[]
                    {
                        new LimitationDetailItem
                        {
                            ProductId=prodcutId1,
                            ProductName=productName1,
                            ProductAmount=100,
                        },
                        new LimitationDetailItem
                        {
                            ProductId=prodcutId2,
                            ProductName=productName2,
                            ProductAmount=1000,
                        },
                    }
                },
                new LimitationItem()
                {
                    CompanyId =companyId2,
                    CompanyName =companyName2,
                },
            };
    }
}
