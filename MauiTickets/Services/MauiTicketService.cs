using MauiTickets.Databases;
using System.Net.Http.Json;
using TicketLibrary.Data;
using TicketLibrary.Services;

namespace MauiTickets.Services;

public class MauiTicketService : ITicketService
{
    HttpClient client = new HttpClient();

    async Task<List<Ticket>> ITicketService.GetAllTicketsAsync()
    {
        return await client.GetFromJsonAsync<List<Ticket>>("https://localhost:7097/api/Ticket/getall");
    }

    public ticketAppDb ticketAppDb { get; set; }

    public MauiTicketService(ticketAppDb db)
    {
        ticketAppDb = db;
    }
    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        await Task.CompletedTask;
        return ticketAppDb.Connection.Table<Ticket>().ToList();
    }
}
