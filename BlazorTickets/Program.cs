using BlazorTickets.Components;
using BlazorTickets.Data;
using BlazorTickets.Services;
using TicketLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ITicketService, WebTicketService>();
builder.Services.AddScoped<IEventService, WebEventService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<PostgresContext>();

var emailPassword =  builder.Configuration["emailPassword"];

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();
app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
