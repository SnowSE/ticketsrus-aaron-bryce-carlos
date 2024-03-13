using BlazorTickets.Data;
using Microsoft.EntityFrameworkCore;
using TicketLibrary.Data;
using TicketLibrary.Services;
namespace BlazorTickets.Services;

public class WebTicketService : ITicketService
{
    PostgresContext _context;
    public WebTicketService(PostgresContext context)
    {
        _context = context;
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

    public void ChangeBaseAddress(string newBaseAddress)
    {
        throw new NotImplementedException();
    }

    public void ChangeConnectivity(bool _IsConnected)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await _context.Tickets.ToListAsync<Ticket>();
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
