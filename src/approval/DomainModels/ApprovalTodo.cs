namespace approval.DomainModels
{
    public class ApprovalTodo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 如果为Empty,代表为总公司经理审批
        /// </summary>
        public Guid CompanyId { get; set; }
        public ApprovalStatus Status { get; private set; } = ApprovalStatus.Pending;
        public ApprovalType Type { get; set; } = ApprovalType.Unknown;
        public string TypeId { get; set; } = string.Empty;

        public void Approve()
        {
            if (Status == ApprovalStatus.Completed) return;
            Status = ApprovalStatus.Completed;
        }
    }

    public enum ApprovalStatus
    {
        Pending = 0,
        Completed = 1,
    }

    public enum ApprovalType
    {
        Unknown = 0,
        /// <summary>
        /// 入库申请
        /// </summary>
        GodownApplication = 1
    }
}
