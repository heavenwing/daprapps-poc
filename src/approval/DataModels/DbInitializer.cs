using approval.DomainModels;

namespace approval.DataModels
{
    public class DbInitializer
    {
        public static void Initialize(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApprovalDbContext>();
                    EnsureCreated(context);
                    //SeedData(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        private static void SeedData(ApprovalDbContext context)
        {
            // Look for any data.
            if (context.ApprovalTodos.Any())
            {
                return;   // DB has been seeded
            }

            var todos = new ApprovalTodo[]
            {
                new ApprovalTodo{Id=Guid.NewGuid(),CompanyId=Guid.Empty,Type=ApprovalType.GodownApplication, TypeId=Guid.NewGuid().ToString()},
                new ApprovalTodo{Id=Guid.NewGuid(),CompanyId=Guid.Empty,Type=ApprovalType.GodownApplication, TypeId=Guid.NewGuid().ToString()},
                new ApprovalTodo{Id=Guid.NewGuid(),CompanyId=Guid.Empty,Type=ApprovalType.GodownApplication, TypeId=Guid.NewGuid().ToString()},
            };
            foreach (var todo in todos)
            {
                context.ApprovalTodos.Add(todo);
            }
            context.SaveChanges();
        }

        private static void EnsureCreated(ApprovalDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
