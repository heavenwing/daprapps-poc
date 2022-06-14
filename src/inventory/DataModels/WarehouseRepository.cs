using inventory.DomainModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;

namespace inventory.DataModels
{
    public class WarehouseRepository
    {
        internal readonly IMongoCollection<Warehouse> warehouseCollection;

        public WarehouseRepository(
            IOptions<InventoryStoreDatabaseSettings> inventoryStoreDatabaseSettings)
        {
            //https://kevsoft.net/2020/06/25/storing-guids-as-strings-in-mongodb-with-csharp.html
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

            var mongoClient = new MongoClient(
                inventoryStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                inventoryStoreDatabaseSettings.Value.DatabaseName);

            warehouseCollection = mongoDatabase.GetCollection<Warehouse>(
                inventoryStoreDatabaseSettings.Value.WarehousesCollectionName);
        }

        public async Task<List<Warehouse>> GetAsync() =>
            await warehouseCollection.Find(_ => true).ToListAsync();

        public async Task<Warehouse?> GetAsync(Guid id) =>
            await warehouseCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<Warehouse>?> GetByCompanyIdAsync(Guid companyId) =>
           await warehouseCollection.Find(x => x.CompanyId == companyId).ToListAsync();

        public async Task CreateAsync(Warehouse newWarehouse) =>
            await warehouseCollection.InsertOneAsync(newWarehouse);

        public async Task UpdateAsync(Guid id, Warehouse updatedWarehouse) =>
            await warehouseCollection.ReplaceOneAsync(x => x.Id == id, updatedWarehouse);

        public async Task RemoveAsync(Guid id) =>
            await warehouseCollection.DeleteOneAsync(x => x.Id == id);
    }
}
