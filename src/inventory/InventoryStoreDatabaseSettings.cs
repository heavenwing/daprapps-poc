namespace inventory
{
    public class InventoryStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string WarehousesCollectionName { get; set; } = null!;
    }
}
