using System.Diagnostics.Metrics;
using BlazorTickets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketLibrary.Data;
using TicketLibrary.Services;
namespace BlazorTickets.Services;



public partial class WebEventService : IEventService
{
    private readonly ILogger<WebEventService> _logger;


    [LoggerMessage(Level = LogLevel.Information, Message = "Getting All Events.")]
    static partial void GetAllEvents(ILogger logger, string description);

    [LoggerMessage(Level = LogLevel.Error, Message = "Testing the events.")]
    static partial void TestEvents1(ILogger logger, string description);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Something about events.")]
    static partial void TestEvents2(ILogger logger, string description);
 

    PostgresContext _context;
    public WebEventService(PostgresContext context, ILogger<WebEventService> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<Event>> GetAllEventsAsync()
    {
        GetAllEvents(_logger, $"Inside getAllEvents now. Number of events is {_context.Events.Count()}");
        bryceMetrics.upDownCounter.Add(4);
        return await _context.Events.ToListAsync<Event>();
    }

    public void InvokeEventsLogger1(int num1)
    {
        TestEvents1(_logger, $"Inside invokeEvents now. {num1}");
    }

    public void InvokeEventsLogger2(int num2)
    {
        bryceMetrics.observableInt += 5;
        TestEvents2(_logger, $"invoking events again. {num2}");

    }
}
