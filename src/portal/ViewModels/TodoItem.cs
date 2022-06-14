namespace portal.ViewModels
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? CompanyName { get; set; }
        public bool IsDone { get; set; }
        //public string? MoreUrl { get; set; }
    }
}
