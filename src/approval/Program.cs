using approval;
using approval.DataModels;
using Google.Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApprovalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MssqlConnection"));
    //options.UseNpgsql(builder.Configuration.GetConnectionString("PgsqlConnection"));
    //options.UseInMemoryDatabase("approval");
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllers().AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

DbInitializer.Initialize(app);

app.Run();
