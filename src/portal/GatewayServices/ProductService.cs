using AppModels.basicinfo;
using AutoMapper;
using Dapr.Client;
using portal.ViewModels;

namespace portal.GatewayServices
{
    public class ProductService
    {
        private readonly DaprClient daprClient;
        private readonly IMapper mapper;

        public ProductService(
            DaprClient daprClient,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.daprClient = daprClient;
        }

        public async Task<List<ProductItem>> GetProductsAsync()
        {
            var output = await daprClient.InvokeMethodAsync<ProductListOutput>("basicinfo", "api/Product/List");
            return mapper.Map<List<ProductItem>>(output.Items);
        }

        public async Task AddProductAsync(ProductItem item)
        {
            await daprClient.InvokeMethodAsync("basicinfo", "api/Product/Add", mapper.Map<ProductAddInput>(item));
        }

        public async Task UpdateProductAsync(ProductItem item)
        {
            await daprClient.InvokeMethodAsync("basicinfo", "api/Product/Update", mapper.Map<ProductUpdateInput>(item));
        }
    }
}
