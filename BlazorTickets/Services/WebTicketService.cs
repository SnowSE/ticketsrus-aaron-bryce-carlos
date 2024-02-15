﻿using BlazorTickets.Data;
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
        catch (Exception ex) { throw; }
        return Task.CompletedTask;
    }

    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await _context.Tickets.ToListAsync<Ticket>();
    }

    public void SetTimer(int seconds)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateATicket(Ticket t)
    {
        _context.Tickets.Update(t);
        _context.SaveChanges();
    }
}
