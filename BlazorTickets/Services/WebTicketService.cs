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
        _context.Tickets.Add(t);
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await _context.Tickets.ToListAsync<Ticket>();
    }

    public async Task UpdateATicket(Ticket t)
    {
        _context.Tickets.Update(t);
        _context.SaveChanges();
    }
}
