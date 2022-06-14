using System.Security.Principal;
using System.Threading;
using AppModels.approval;
using AppModels.Common;
using Dapr.Client;
using Google.Type;
using NuGet.Packaging.Signing;
using portal.Pages;
using portal.ViewModels;

namespace portal.GatewayServices
{
    public class ApprovalTodoService
    {
        private readonly DaprClient daprClient;

        public ApprovalTodoService(DaprClient daprClient)
        {
            this.daprClient = daprClient;
        }

        public async Task<List<TodoItem>> GetTodosAsync()
        {
            var companyId = Guid.Empty;
            var output = await daprClient.InvokeMethodAsync<TodoListInput, TodoListOutput>("approval", "api/Todo/List",
                new TodoListInput { CompanyId = companyId });

            var companyIds = output.Items.Select(p => p.CompanyId).ToArray();
            var outputCompanyGetNames = await daprClient.InvokeMethodAsync<GetNamesInput, GetNamesOutput>("basicinfo", "api/Company/GetNames",
                new GetNamesInput { Ids = companyIds });

            var result = new List<TodoItem>();
            foreach (var item in output.Items)
            {
                result.Add(new TodoItem
                {
                    Id = item.Id,
                    Title = $"入库申请审批-{item.TypeId}",
                    CompanyName = item.CompanyId == Guid.Empty ? "总公司" : outputCompanyGetNames.Items[item.CompanyId]
                });
            }
            return result;
        }

        public async Task ApproveTodosAsync(IEnumerable<TodoItem> items)
        {
            if (items == null || items.Count() == 0) return;
            await daprClient.InvokeMethodAsync("approval", "api/Todo/Approve",
                   new TodoApproveInput { Ids = items.Select(p => p.Id).ToArray() });
        }
    }
}
