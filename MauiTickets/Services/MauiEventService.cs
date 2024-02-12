using MauiTickets.Databases;
using System.Net.Http.Json;
using TicketLibrary.Data;
using TicketLibrary.Services;
using SQLite;


namespace MauiTickets.Services;

public class MauiEventService : IEventService
{
    HttpClient client = new HttpClient();

    async Task<List<Event>> IEventService.GetAllEventsAsync()
    {
        return await client.GetFromJsonAsync<List<Event>>("https://localhost:7097/api/Event/getall");
    }

    public ticketAppDb ticketAppDb { get; set; }

    public MauiEventService(ticketAppDb db)
    {
        ticketAppDb = db;
    }
    public async Task<List<Event>> GetAllEventsAsync()
    {
        await Task.CompletedTask;
        return ticketAppDb.Connection.Table<Event>().ToList();
    }
}
