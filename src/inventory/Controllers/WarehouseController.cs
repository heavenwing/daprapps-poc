using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using AppModels.godown;
using AppModels.inventory;
using AutoMapper;
using Dapr;
using Dapr.Client;
using inventory.DataModels;
using inventory.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private const string PubSubName = "pubsub";

        private readonly WarehouseRepository repository;
        private readonly InventoryDbContext db;
        private readonly DaprClient daprClient;
        private readonly IMapper mapper;
        private readonly ILogger<WarehouseController> logger;

        public WarehouseController(
            WarehouseRepository repository,
            InventoryDbContext db,
            DaprClient daprClient,
            IMapper mapper,
            ILogger<WarehouseController> logger)
        {
            this.repository = repository;
            this.db = db;
            this.daprClient = daprClient;
            this.mapper = mapper;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpPost("GetQuantities")]
        public async Task<WarehouseGetQuantitiesOutput> GetQuantitiesByCompanyId(WarehouseGetQuantitiesInput input)
        {
            //var query = from w in db.Warehouses
            //            where w.CompanyId == input.CompanyId
            //            select w;
            //var warehouses = await query.ToListAsync();// new List<Warehouse>();
            //var warehouses = await Task.FromResult(new List<Warehouse>());
            var warehouses = await repository.GetByCompanyIdAsync(input.CompanyId);
            if (warehouses == null)
                throw new ArgumentNullException(nameof(warehouses), input.CompanyId.ToString());

            var output = new WarehouseGetQuantitiesOutput();
            foreach (var id in input.ProductIds)
            {
                output.Items.Add(id, WarehouseService.SumQuantityByWarehouses(warehouses, id));
            }
            return output;
        }

        [Topic(PubSubName, nameof(PutStorageEvent))]
        [HttpPost("PutStorage")]
        public async Task PutStorage(PutStorageEvent input)
        {
            //TODO keep idempotent by input.StorageOrderId

            var warehouse = await repository.GetAsync(input.WarehouseId);
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse), input.WarehouseId.ToString());

            foreach (var d in input.Details)
            {
                var binlocation = warehouse.Binlocations.FirstOrDefault(p => p.Id == d.BinlocationId);
                if (binlocation == null)
                    throw new ArgumentOutOfRangeException("binlocation not found: " + d.BinlocationId);
                binlocation.Stocks.Add(new Stock
                {
                    ProductId = d.ProductId,
                    Quantity = d.ProductAmount
                });
            }

            await repository.UpdateAsync(input.WarehouseId, warehouse);
        }

        [HttpPost("Init")]
        public async Task<WarehouseInitOutput> InitAsync(WarehouseInitInput input)
        {
            var defaultStocks = input.ProductIds.Select(p => new Stock
            {
                ProductId = p
            }).ToArray();
            var warehouse = new Warehouse
            {
                Id = Guid.NewGuid(),
                CompanyId = input.CompanyId,
                Name = input.WarehouseName,
                Binlocations = new[]
                    {
                        new Binlocation
                        {
                            Id="AAA",
                            Stocks = defaultStocks,
                        },
                        new Binlocation
                        {
                            Id="BBB",
                            Stocks = defaultStocks,
                        },
                        new Binlocation
                        {
                            Id="CCC",
                            Stocks = defaultStocks,
                        }
                    }
            };
            await repository.CreateAsync(warehouse);
            return new WarehouseInitOutput { Id = warehouse.Id };
        }

        [HttpPost("List")]
        public async Task<List<Warehouse>> ListAsync()
        {
            return await repository.GetAsync();
        }
    }
}
