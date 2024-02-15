using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketLibrary.Data;

namespace TicketLibrary.Services;

public interface ITicketService
{
    public Task<List<Ticket>> GetAllTicketsAsync();

    public Task AddATicket(Ticket ticket);

    public Task UpdateATicket(Ticket t);

    public void SetTimer(int seconds);
 
}
