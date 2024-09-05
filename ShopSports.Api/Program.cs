using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using ShopSports.Api.Repositories;
using ShopSports.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IPriceService, PriceService>();
builder.Services.AddSingleton<IInventoryService, InventoryService>();

// Metrics configuration.

var openTelemetryBuilder = builder.Services.AddOpenTelemetry();

openTelemetryBuilder.ConfigureResource(resource => resource
    .AddService(builder.Environment.ApplicationName));

openTelemetryBuilder.WithMetrics(metrics => metrics
    .AddAspNetCoreInstrumentation()
    .AddConsoleExporter()
    .AddPrometheusExporter());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

// Configure the Prometheus scraping endpoint
app.MapPrometheusScrapingEndpoint();

app.Run();
