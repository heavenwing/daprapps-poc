using System.Collections.Generic;
using AppModels.basicinfo;
using AppModels.basicsetting;
using AppModels.Common;
using AutoMapper;
using Dapr.Client;
using NuGet.Packaging;
using portal.ViewModels;

namespace portal.GatewayServices
{
    public class BizScopeService
    {
        private readonly DaprClient daprClient;
        private readonly IMapper mapper;

        public BizScopeService(
            DaprClient daprClient,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.daprClient = daprClient;
        }

        public async Task<List<BizEntityItem>> GetBizEntitiesAsync()
        {
            var items = new List<BizEntityItem>();

            var outputBizScopeList = await daprClient.InvokeMethodAsync<BizScopeListOutput>("basicsetting", "api/BizScope/List");

            if (outputBizScopeList.Items.Length > 0)
            {
                var bizEntityIds = outputBizScopeList.Items.Select(p => p.BizEntityId).ToArray();
                var outputCompanyGetNames = await daprClient.InvokeMethodAsync<GetNamesInput, GetNamesOutput>("basicinfo", "api/Company/GetNames",
                    new GetNamesInput { Ids = bizEntityIds });
                var outputProviderGetNames = await daprClient.InvokeMethodAsync<GetNamesInput, GetNamesOutput>("basicinfo", "api/Provider/GetNames",
                    new GetNamesInput { Ids = bizEntityIds });
                var bizEntityNames = new Dictionary<Guid, string>();
                foreach (var item in outputCompanyGetNames.Items)
                {
                    bizEntityNames.Add(item.Key, item.Value);
                }
                foreach (var item in outputProviderGetNames.Items)
                {
                    bizEntityNames.Add(item.Key, item.Value);
                }

                var queryProductIds = from o in outputBizScopeList.Items
                                      from s in o.ProductIds
                                      select s;
                var productIds = queryProductIds.Distinct().ToArray();
                var outputProductGetNames = await daprClient.InvokeMethodAsync<GetNamesInput, GetNamesOutput>("basicinfo", "api/Product/GetNames",
                    new GetNamesInput { Ids = productIds });

                foreach (var bizScope in outputBizScopeList.Items)
                {
                    var item = new BizEntityItem
                    {
                        Id = bizScope.BizEntityId,
                        Name = bizEntityNames[bizScope.BizEntityId],
                        Scopes = new List<BizScopeItem>(),
                    };
                    foreach (var productId in bizScope.ProductIds)
                    {
                        var scope = new BizScopeItem
                        {
                            ProductId = productId,
                            ProductName = outputProductGetNames.Items[productId],
                        };
                        item.Scopes.Add(scope);
                    }
                    items.Add(item);
                }
            }

            return items;
        }

        public async Task SaveScopesAsync(BizEntityItem item)
        {
            await daprClient.InvokeMethodAsync("basicsetting", "api/BizScope/Save",
                new BizScopeSaveInput
                {
                    BizEntityId = item.Id,
                    ProductIds = item.Scopes.Select(p => p.ProductId).ToArray(),
                });
        }
    }
}
