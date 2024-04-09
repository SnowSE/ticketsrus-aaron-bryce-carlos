using System.Reflection.Metadata.Ecma335;
using BlazorTickets;
using BlazorTickets.Components;
using BlazorTickets.Data;
using BlazorTickets.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using TicketLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<ITicketService, WebTicketService>();
builder.Services.AddScoped<IEventService, WebEventService>();
builder.Services.AddControllers();
builder.Services.AddScoped<MailMailMail>();
builder.Services.AddDbContext<PostgresContext>(options => options.UseNpgsql(builder.Configuration["Postgres"]));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddLogging();

const string serviceName = "bryceservice";
var serviceVersion = "1.0.0";


builder.Logging.AddOpenTelemetry(options =>
{
    options
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName))
        .AddConsoleExporter()
        .AddOtlpExporter(o =>
        o.Endpoint = new Uri(builder.Configuration["COLLECTOR_URL"] ?? throw new NullReferenceException("environment variable not set: COLLECTOR_URL"))
      );
});

builder.Services.AddOpenTelemetry()
  .ConfigureResource(r => r.AddService(serviceName))
  .WithTracing(b =>
      b
      .AddAspNetCoreInstrumentation()
      .AddSource(bryceTrace.serviceName1)
      .AddSource(bryceTrace.serviceName2)
      .AddConsoleExporter()
      .AddOtlpExporter(o =>
        o.Endpoint = new Uri("http://otel-collector:4317")))
  .WithMetrics(metrics => metrics
    // Metrics provider from OpenTelemetry
    .AddAspNetCoreInstrumentation()
    .AddMeter(bryceMetrics.Meter.Name)
    .AddConsoleExporter()
    .AddOtlpExporter(o =>
        o.Endpoint = new Uri("http://otel-collector:4317"))
  );


//Add health checks service
builder.Services.AddHealthChecks();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapHealthChecks("/health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public partial class Program { };
