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
    public class ReceiptOrderController : ControllerBase
    {
        private const string StateName = "statestore";

        private readonly DaprClient daprClient;
        private readonly IMapper mapper;
        private readonly ILogger<ReceiptOrderController> logger;

        public ReceiptOrderController(
            DaprClient daprClient,
            IMapper mapper,
            ILogger<ReceiptOrderController> logger)
        {
            this.daprClient = daprClient;
            this.mapper = mapper;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private static string GetStateKey(string id)
        {
            return $"{nameof(ReceiptOrder)}:{id}";
        }

        [HttpPost("Create")]
        public async Task<ReceiptOrderCreateOutput> CreateAsync(ReceiptOrderCreateInput input)
        {
            var id = Guid.NewGuid().ToString();
            var entity = mapper.Map<ReceiptOrder>(input);
            entity.Id = new Guid(id);
            await daprClient.SaveStateAsync(StateName, GetStateKey(id), entity);

            return new ReceiptOrderCreateOutput { Success = true, Id = id };
        }

        [HttpPost("Load")]
        public async Task<ReceiptOrderLoadOutput> LoadAsync(ApplicationWorkflowInput input)
        {
            var entity = await daprClient.GetStateAsync<ReceiptOrder>(StateName, GetStateKey(input.Id));
            return mapper.Map<ReceiptOrderLoadOutput>(entity);
        }
    }
}
