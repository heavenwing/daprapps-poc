namespace AppModels.approval
{
    public class TodoListInput
    {
        public Guid CompanyId { get; set; }
    }

    public class TodoListOutput
    {
        public TodoListDto[] Items { get; set; } = Array.Empty<TodoListDto>();
    }

    public class TodoListDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int Status { get; private set; }
        public int Type { get; set; }
        public string? TypeId { get; set; }
    }

    public class TodoApproveInput
    {
        public Guid[] Ids { get; set; } = Array.Empty<Guid>();
    }

    public class TodoCheckInput
    {
        public Guid Id { get; set; }
    }

    public class TodoCheckOutput
    {
        public bool Complete { get; set; }
    }

    public class TodoCreateGodownApplicationApprovalInput
    {
        public string? Id { get; set; }
        public bool IsHead { get; set; }
    }

    public class TodoCreateOutput
    {
        public Guid Id { get; set; }
    }
}
