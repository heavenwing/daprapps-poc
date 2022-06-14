using Google.Api;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using portal;
using portal.Data;
using portal.GatewayServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddDapr();
builder.Services.AddServerSideBlazor();
builder.Services.AddBootstrapBlazor();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ApprovalTodoService>();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<BizScopeService>();
builder.Services.AddSingleton<LimitationService>();

builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
