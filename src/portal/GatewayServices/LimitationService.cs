using System.Collections.Generic;
using AppModels.basicsetting;
using AppModels.Common;
using AutoMapper;
using Dapr.Client;
using portal.ViewModels;

namespace portal.GatewayServices
{
    public class LimitationService
    {
        private readonly DaprClient daprClient;
        private readonly IMapper mapper;

        public LimitationService(
            DaprClient daprClient,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.daprClient = daprClient;
        }

        public async Task<List<LimitationItem>> GetLimitationsAsync()
        {
            var items = new List<LimitationItem>();

            var outputLimitationList = await daprClient.InvokeMethodAsync<LimitationListOutput>("basicsetting", "api/Limitation/List");

            var companyIds = outputLimitationList.Items.Select(x => x.CompanyId).ToArray();
            var outputCompanyGetNames = await daprClient.InvokeMethodAsync<GetNamesInput, GetNamesOutput>("basicinfo", "api/Company/GetNames",
                new GetNamesInput { Ids = companyIds });

            var queryProductIds = from l in outputLimitationList.Items
                                  from d in l.Details
                                  select d.ProductId;
            var productIds = queryProductIds.Distinct().ToArray();
            var outputProductGetNames = await daprClient.InvokeMethodAsync<GetNamesInput, GetNamesOutput>("basicinfo", "api/Product/GetNames",
                new GetNamesInput { Ids = productIds });

            foreach (var l in outputLimitationList.Items)
            {
                var item = new LimitationItem
                {
                    CompanyId = l.CompanyId,
                    CompanyName = outputCompanyGetNames.Items[l.CompanyId],
                };
                foreach (var d in l.Details)
                {
                    var scope = new LimitationDetailItem
                    {
                        ProductId = d.ProductId,
                        ProductName = outputProductGetNames.Items[d.ProductId],
                        ProductAmount = d.Amount,
                    };
                    item.Details.Add(scope);
                }
                items.Add(item);
            }

            return items;
        }

        public async Task SaveLimitationAsync(LimitationItem item)
        {
            await daprClient.InvokeMethodAsync("basicsetting", "api/Limitation/Save",
                new LimitationSaveInput
                {
                    CompanyId = item.CompanyId,
                    Details = item.Details.Select(d => new LimitationDetailDto
                    {
                        ProductId = d.ProductId,
                        Amount = d.ProductAmount
                    }).ToArray(),
                });
        }
    }
}
