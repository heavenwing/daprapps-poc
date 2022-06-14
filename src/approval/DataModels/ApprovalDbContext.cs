using approval.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace approval.DataModels
{
    public class ApprovalDbContext : DbContext
    {
        public ApprovalDbContext(DbContextOptions<ApprovalDbContext> options) : base(options)
        {
        }

        public DbSet<ApprovalTodo> ApprovalTodos { get; set; }
    }
}
