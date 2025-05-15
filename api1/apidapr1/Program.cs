
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using OpenTelemetry;
using OpenTelemetry.Logs;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDaprClient();


builder.Services.AddOpenTelemetry()
    .WithTracing(b => b.AddSource("*")
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation().AddZipkinExporter(c=> c.Endpoint = new Uri("http://zipkin:9411/api/v2/spans")))
    .WithMetrics(b => b.AddMeter("*")
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation().AddConsoleExporter())
    .WithLogging(b => b.AddConsoleExporter());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.UseAuthorization();

app.MapControllers();

app.Run();
