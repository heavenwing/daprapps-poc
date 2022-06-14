namespace portal.ViewModels
{
    public class BizEntityItem
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<BizScopeItem> Scopes { get; set; } = new List<BizScopeItem>();
    }

    public class BizScopeItem
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}
