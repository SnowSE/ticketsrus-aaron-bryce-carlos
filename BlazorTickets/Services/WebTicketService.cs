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
    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await _context.Tickets.ToListAsync<Ticket>();
    }
}
