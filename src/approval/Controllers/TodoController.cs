using AppModels.approval;
using AppModels.godown;
using approval.DataModels;
using approval.DomainModels;
using AutoMapper;
using Dapr.Actors.Client;
using Dapr.Actors;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AppModels;

namespace approval.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApprovalDbContext db;
        private readonly DaprClient daprClient;
        private readonly IMapper mapper;
        private readonly ILogger<TodoController> logger;

        public TodoController(
            ApprovalDbContext db,
            DaprClient daprClient,
            IMapper mapper,
            ILogger<TodoController> logger)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.daprClient = daprClient;
            this.mapper = mapper;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("List")]
        public async Task<TodoListOutput> GetByCompanyAsync(TodoListInput input)
        {
            var query = from item in db.ApprovalTodos
                        where item.Status == ApprovalStatus.Pending //&& item.CompanyId == input.CompanyId
                        select item;
            var items = await query.ToListAsync();
            return new TodoListOutput { Items = mapper.Map<TodoListDto[]>(items) };
        }

        [HttpPost("Check")]
        public async Task<TodoCheckOutput> CheckAsync(TodoCheckInput input)
        {
            logger.LogInformation("==poc== CheckAsync: " + input.Id);

            var query = from item in db.ApprovalTodos
                        where item.Id == input.Id
                        select item.Status;
            var status = await query.FirstOrDefaultAsync();
            return new TodoCheckOutput
            {
                Complete = status == ApprovalStatus.Completed
            };
        }

        private async Task<ApprovalTodo> GetTodoByIdAsync(Guid id)
        {
            var query = from item in db.ApprovalTodos
                        where item.Id == id
                        select item;
            var todo = await query.FirstOrDefaultAsync();
            return todo;
        }

        private async Task<List<ApprovalTodo>> GetTodosByIdsAsync(Guid[] ids)
        {
            if (ids == null || ids.Length == 0)
                return new List<ApprovalTodo>();

            var query = from item in db.ApprovalTodos
                        where ids.Contains(item.Id)
                        select item;
            var todos = await query.ToListAsync();
            return todos;
        }

        [HttpPost("Approve")]
        public async Task ApproveAsync(TodoApproveInput input)
        {
            var todos = await GetTodosByIdsAsync(input.Ids);
            todos.ForEach(p => p.Approve());
            await db.SaveChangesAsync();
        }

        [HttpPost("CreateGodownApplicationApproval")]
        public async Task<TodoCreateOutput> CreateGodownApplicationApprovalAsync(TodoCreateGodownApplicationApprovalInput input)
        {
            logger.LogInformation("==poc== CreateGodownApplicationApprovalAsync: " + input.Id);

            if (input is null || input.Id is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            //var actorId = new ActorId(input.Id);
            //var proxy = ActorProxy.Create<IApplicationFormActor>(actorId, Constants.ApplicationFormActorName);
            //var dtoApplicationForm = await proxy.GetData();

            var item = new ApprovalTodo
            {
                Type = ApprovalType.GodownApplication,
                TypeId = input.Id,
            };
            if (input.IsHead)
            {
                item.CompanyId = Guid.Empty;
            }
            else
            {
                var output = await daprClient.InvokeMethodAsync<ApplicationWorkflowInput, ApplicationOrderLoadOutput>(
                    "godown", "api/ApplicationOrder/Load",
                    new ApplicationWorkflowInput { Id = input.Id });
                item.CompanyId = output.CompanyId;
            }

            var query = from a in db.ApprovalTodos
                        where a.TypeId == input.Id && a.CompanyId == item.CompanyId
                        select a.Id;
            var oldItemId = await query.FirstOrDefaultAsync();
            if (oldItemId != Guid.Empty)
                return new TodoCreateOutput { Id = oldItemId };

            db.ApprovalTodos.Add(item);
            db.SaveChanges();

            return new TodoCreateOutput { Id = item.Id };
        }
    }
}
