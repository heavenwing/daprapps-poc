using AppModels;
using AppModels.basicsetting;
using AppModels.godown;
using AppModels.inventory;
using AutoMapper;
using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Client;
using godown.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace godown.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationOrderController : ControllerBase
    {
        private const string StateName = "statestore";

        private readonly DaprClient daprClient;
        private readonly IMapper mapper;
        private readonly ILogger<ApplicationOrderController> logger;

        public ApplicationOrderController(
            DaprClient daprClient,
            IMapper mapper,
            ILogger<ApplicationOrderController> logger)
        {
            this.daprClient = daprClient;
            this.mapper = mapper;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private static string GetStateKey(string id)
        {
            return $"{nameof(ApplicationOrder)}:{id}";
        }

        [HttpPost("Create")]
        public async Task<ApplicationOrderCreateOutput> CreateAsync(ApplicationOrderCreateInput input)
        {
            //validate allowable
            var outputBizScopeGetAllowable = await daprClient.InvokeMethodAsync<BizScopeGetAllowableInput, BizScopeGetAllowableOutput>(
                "basicsetting", "api/BizScope/GetAllowable",
                new BizScopeGetAllowableInput
                {
                    CompanyId = input.CompanyId,
                    ProviderId = input.ProviderId,
                });
            bool hasUnallow = false;
            foreach (var d in input.Details)
            {
                if (!outputBizScopeGetAllowable.Items.Contains(d.ProductId))
                {
                    hasUnallow = true;
                    break;
                }
            }
            if (hasUnallow) return new ApplicationOrderCreateOutput { Success = false };

            //create actor 
            //NOTE encounter XmlSerialization Exception https://github.com/dapr/dotnet-sdk/issues/278
            //var actorId = new ActorId(Guid.NewGuid().ToString());
            //var proxy = ActorProxy.Create<IApplicationFormActor>(actorId, Constants.ApplicationFormActorName);
            //await proxy.SaveData(input);

            //use state management
            var id = Guid.NewGuid().ToString();
            var entity = mapper.Map<ApplicationOrder>(input);
            entity.Id = new Guid(id);
            await daprClient.SaveStateAsync(StateName, GetStateKey(id), entity);

            //trigger workflow
            await daprClient.PublishEventAsync("workflows", "GodownApplication",
                new ApplicationWorkflowInput { Id = id });

            return new ApplicationOrderCreateOutput
            {
                Id = id,
                Success = true
            };
        }

        [HttpPost("CheckLimitation")]
        public async Task<ApplicationOrderCheckLimitationOutput> CheckLimitationAsync(ApplicationWorkflowInput input)
        {
            if (input is null || input.Id is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            //var actorId = new ActorId(input.Id);
            //var proxy = ActorProxy.Create<IApplicationFormActor>(actorId, Constants.ApplicationFormActorName);
            //var dtoApplicationForm = await proxy.GetData();

            var entity = await daprClient.GetStateAsync<ApplicationOrder>(StateName, GetStateKey(input.Id));

            var outputLimitationGetAmount = await daprClient.InvokeMethodAsync<LimitationGetAmountInput, LimitationGetAmountOutput>(
                "basicsetting", "api/Limitation/GetAmount",
                new LimitationGetAmountInput
                {
                    CompanyId = entity.CompanyId,
                    ProductIds = entity.Details.Select(x => x.ProductId).ToArray(),
                });

            var outputWarehouseGetQuantities = await daprClient.InvokeMethodAsync<WarehouseGetQuantitiesInput, WarehouseGetQuantitiesOutput>(
                "inventory", "api/Warehouse/GetQuantities",
                new WarehouseGetQuantitiesInput
                {
                    CompanyId = entity.CompanyId,
                    ProductIds = entity.Details.Select(x => x.ProductId).ToArray(),
                });


            //if (await proxy.IsExceeded(new ApplicationFormIsExceededDto
            //{
            //    InventoryQuantities = outputWarehouseGetQuantities.Items,
            //    LimitAmounts = outputLimitationGetAmount.Items,
            //}))
            if (entity.IfExceeded(outputWarehouseGetQuantities.Items, outputLimitationGetAmount.Items))
            {
                return new ApplicationOrderCheckLimitationOutput { Exceed = true };
            }
            return new ApplicationOrderCheckLimitationOutput { Exceed = false };
        }

        [HttpPost("Load")]
        public async Task<ApplicationOrderLoadOutput> LoadAsync(ApplicationWorkflowInput input)
        {
            var entity = await daprClient.GetStateAsync<ApplicationOrder>(StateName, GetStateKey(input.Id));
            return mapper.Map<ApplicationOrderLoadOutput>(entity);
        }

        [HttpPost("Complete")]
        public async Task CompleteAsync(ApplicationWorkflowInput input)
        {
            var key = GetStateKey(input.Id);
            var entity = await daprClient.GetStateAsync<ApplicationOrder>(StateName, key);
            entity.Complete();
            await daprClient.SaveStateAsync(StateName, key, entity);
        }
    }
}
