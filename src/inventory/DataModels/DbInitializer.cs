using Google.Api;
using inventory.DomainModels;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace inventory.DataModels
{
    public class DbInitializer
    {
        public static void Initialize(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<InventoryDbContext>();
                    EnsureCreated(context);
                    SeedData(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        private static void SeedData(InventoryDbContext context)
        {
            // Look for any data.
            if (context.Warehouses.Any())
            {
                return;   // DB has been seeded
            }

            var items = GenereateData();
            items.ForEach(item => context.Warehouses.Add(item));
            context.SaveChanges();
        }

        private static List<Warehouse> GenereateData()
        {
            var companyId = Guid.Empty;
            var items = new List<Warehouse>();
            for (int i = 0; i < 1; i++)
            {
                var id = Guid.NewGuid();
                var item = new Warehouse
                {
                    Id = id,
                    CompanyId = companyId,
                    Name = "Warehouse " + i,
                    Binlocations = new[]
                    {
                        new Binlocation
                        {
                            Id="AAA",
                            Stocks = Array.Empty<Stock>(),
                        },
                        new Binlocation
                        {
                            Id="BBB",
                            Stocks = Array.Empty<Stock>(),
                        },
                        new Binlocation
                        {
                            Id="CCC",
                            Stocks = Array.Empty<Stock>(),
                        }
                    }
                };
                items.Add(item);
            }

            return items;
        }

        internal static void InitializeMongo(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var repository = services.GetRequiredService<WarehouseRepository>();
                    SeedMongoData(repository);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        private static void SeedMongoData(WarehouseRepository repository)
        {
            // Look for any data.
            if (repository.warehouseCollection.EstimatedDocumentCount() > 0)
            {
                return;   // DB has been seeded
            }

            var items = GenereateData();
            repository.warehouseCollection.InsertMany(items);
        }

        private static void EnsureCreated(InventoryDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
