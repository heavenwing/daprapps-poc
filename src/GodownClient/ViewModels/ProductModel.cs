namespace GodownClient.ViewModels
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductAmount { get; set; }
        public int AllowAmount { get; set; }
    }

    //public class ProviderModel
    //{
    //    public Guid Id { get; set; }
    //    public string? Name { get; set; }
    //}
}
