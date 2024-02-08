using System.Net.Http.Json;
using TicketLibrary.Data;
using TicketLibrary.Services;

namespace MauiTickets.Services;

public class MauiEventService : IEventService
{
    HttpClient client = new HttpClient();

    async Task<List<Event>> IEventService.GetAllEventsAsync()
    {
        return await client.GetFromJsonAsync<List<Event>>("https://localhost:7097/api/Event/getall");
    }
}
