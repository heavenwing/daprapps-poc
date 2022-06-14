namespace inventory.DomainModels
{
    public class WarehouseService
    {
        public static int SumQuantityByWarehouses(IEnumerable<Warehouse> warehouses, Guid productId)
        {
            if (warehouses == null) return 0;
            return warehouses.Sum(p => p.SumQuantityByProductId(productId));
        }
    }
}
