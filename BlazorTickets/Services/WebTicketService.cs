using BlazorTickets.Data;
using Microsoft.EntityFrameworkCore;
using TicketLibrary.Data;
using TicketLibrary.Services;
namespace BlazorTickets.Services;

public partial class WebTicketService : ITicketService
{
    private readonly ILogger<WebTicketService> _logger;


    [LoggerMessage(Level = LogLevel.Information, Message = "Getting All Tickets.")]
    static partial void GetAllTickets(ILogger logger, string description);

    [LoggerMessage(Level = LogLevel.Error, Message = "Testing the tickets.")]
    static partial void TestTickets1(ILogger logger, string description);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Something about tickets.")]
    static partial void TestTickets2(ILogger logger, string description);


    PostgresContext _context;
    public WebTicketService(PostgresContext context, ILogger<WebTicketService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task AddATicket(Ticket t)
    {
        try
        {
            t.Id = _context.Tickets.Max(t => t.Id) + 1;
            _context.Tickets.Add(t);
            _context.SaveChanges();
        }
        catch (Exception) { throw; }
        return Task.CompletedTask;
    }

    public void InvokeTicketsLogger1(int number1)
    {
        TestTickets1(_logger, $"Inside invokeTickets now. {number1}");
    }

    public void InvokeTicketsLogger2(int number2)
    {
        TestTickets1(_logger, $"Invoke number 2 for tickets {number2}");
    }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        GetAllTickets(_logger, $"Inside of getAllTickets. Number of tickets is {_context.Tickets.Count()}");
        return await _context.Tickets.ToListAsync<Ticket>();
    }







    public void ChangeBaseAddress(string newBaseAddress)
    {
        throw new NotImplementedException();
    }

    public void ChangeConnectivity(bool _IsConnected)
    {
        throw new NotImplementedException();
    }


    public Task ResetLocalTicketsDB()
    {
        throw new NotImplementedException();
    }

    public Task SyncDatabases()
    {
        throw new NotImplementedException();
    }

    public void UpdateATicket(Ticket t)
    {
        _context.Tickets.Update(t);
        _context.SaveChanges();
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    async Task ITicketService.ChangeBaseAddress(string newBaseAddress)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    async Task ITicketService.SetTimer(int seconds)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    async Task ITicketService.UpdateATicket(Ticket t)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
    }
}
