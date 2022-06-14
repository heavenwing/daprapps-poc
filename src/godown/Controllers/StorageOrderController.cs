using AppModels.godown;
using AutoMapper;
using Dapr.Client;
using godown.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace godown.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageOrderController : ControllerBase
    {
        private const string StateName = "statestore";
        private const string PubSubName = "pubsub";

        private readonly DaprClient daprClient;
        private readonly IMapper mapper;
        private readonly ILogger<StorageOrderController> logger;

        public StorageOrderController(
            DaprClient daprClient,
            IMapper mapper,
            ILogger<StorageOrderController> logger)
        {
            this.daprClient = daprClient;
            this.mapper = mapper;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private static string GetStateKey(string id)
        {
            return $"{nameof(StorageOrder)}:{id}";
        }

        [HttpPost("Create")]
        public async Task<StorageOrderCreateOutput> CreateAsync(StorageOrderCreateInput input)
        {
            //TODO one StorageOrder for one ReceiptOrder

            var id = Guid.NewGuid().ToString();
            var entity = mapper.Map<StorageOrder>(input);
            entity.Id = new Guid(id);
            await daprClient.SaveStateAsync(StateName, GetStateKey(id), entity);

            //publish PutStorageEvent
            await daprClient.PublishEventAsync(PubSubName, nameof(PutStorageEvent),
                new PutStorageEvent
                {
                    StorageOrderId = entity.Id,
                    WarehouseId = input.WarehouseId,
                    Details = input.Details
                });

            return new StorageOrderCreateOutput { Success = true, Id = id };
        }

        [HttpPost("Load")]
        public async Task<StorageOrderLoadOutput> LoadAsync(ApplicationWorkflowInput input)
        {
            var entity = await daprClient.GetStateAsync<StorageOrder>(StateName, GetStateKey(input.Id));
            return mapper.Map<StorageOrderLoadOutput>(entity);
        }
    }
}
