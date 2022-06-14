namespace GodownClient.ViewModels
{
    public class BasicInfoModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    //public class ProviderModel
    //{
    //    public Guid Id { get; set; }
    //    public string? Name { get; set; }
    //}
}
