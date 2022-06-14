using inventory;
using inventory.DataModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InventoryDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseInMemoryDatabase("inventory");
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.Configure<InventoryStoreDatabaseSettings>(
    builder.Configuration.GetSection("InventoryStoreDatabase"));

builder.Services.AddSingleton<WarehouseRepository>();

builder.Services.AddControllers()
    .AddDapr();
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

app.UseCloudEvents();

app.UseAuthorization();

app.MapSubscribeHandler();
app.MapControllers();

//DbInitializer.InitializeMongo(app);

app.Run();
