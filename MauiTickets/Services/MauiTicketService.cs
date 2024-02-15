using MauiTickets.Databases;
using Microsoft.Maui.Animations;
using System.Net.Http.Json;
using TicketLibrary.Data;
using TicketLibrary.Services;

namespace MauiTickets.Services;

public class MauiTicketService : ITicketService
{
    HttpClient client = new HttpClient() { BaseAddress = new Uri("https://blazortickets20240214165128.azurewebsites.net")};
    public ticketAppDb ticketAppDb { get; set; }
    public bool isConnected { get; set; }

    public MauiTicketService(ticketAppDb db)
    {
        ticketAppDb = db;
        //ResetLocalTicketsDB();
        //SyncDatabases();
        //SetTimer(20);
    }
    public async Task ResetLocalTicketsDB()
    {
        try
        {

        // This was because our local DB was duplicating stuff
        ticketAppDb.Connection.DeleteAll<Ticket>();
        List<Ticket> temptick = await client.GetFromJsonAsync<List<Ticket>>("/api/Ticket/getall");
        ticketAppDb.Connection.InsertAll(temptick);
        }
        catch (Exception ex) { throw; }
    }


    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        await Task.CompletedTask;
        return ticketAppDb.Connection.Table<Ticket>().ToList();
    }

    public Task AddATicket(Ticket ticket)
    {
        ticketAppDb.Connection.Insert(ticket);
        return Task.CompletedTask;
    }

    public Task UpdateATicket(Ticket ticket)
    {
        ticketAppDb.Connection.Update(ticket);
        return Task.CompletedTask;  
    }

    public void ChangeConnectivity(bool _IsConnected)
    {
        isConnected = _IsConnected;
    }

    public async Task SetTimer(int seconds)
    {
        var startTimeSpan = TimeSpan.Zero;
        var periodTimeSpan = TimeSpan.FromSeconds(seconds);

        var timer = new System.Threading.Timer(async (e) =>
        {
            await SyncDatabases();
        }, null, startTimeSpan, periodTimeSpan);
    }


    public async Task SyncDatabases()
    {
        if(isConnected)
        {
            List<Ticket> onlineTickets = await client.GetFromJsonAsync<List<Ticket>>("/api/Ticket/getall");
            List<Ticket> localTickets = await GetAllTicketsAsync();

            List<Ticket> temp = new List<Ticket>();

            SyncOnlineToLocal(onlineTickets, localTickets);
            await SyncLocalToOnline(onlineTickets, localTickets);
        }

        await Task.CompletedTask;

    }

    private void SyncOnlineToLocal(List<Ticket> onlineTickets, List<Ticket> localTickets)
    {
        Ticket tempTicket = new();

        foreach (Ticket ticket in onlineTickets)
        {
            if (localTickets.FirstOrDefault(q => q.Ticketnumber == ticket.Ticketnumber) is null)
            {
                tempTicket = ticket;
                //tempTicket.Id = ticket.Id;
                AddATicket(tempTicket);
            }
            else
            {
                if ((localTickets.FirstOrDefault(q => q.Ticketnumber == ticket.Ticketnumber).IsScanned) != ticket.IsScanned)
                {
                    //set the local ticket equal to online
                    UpdateATicket(ticket);
                }
            }
        }
    }

    private async Task SyncLocalToOnline(List<Ticket> onlineTickets, List<Ticket> localTickets)
    {
        foreach (Ticket ticket in localTickets)
        {
          //We assume the ticket exists because only the real database can make tickets
            if ((onlineTickets.FirstOrDefault(q => q.Ticketnumber == ticket.Ticketnumber).IsScanned) != ticket.IsScanned)
            {
                //set the online ticket equal to local
                Ticket tem = ticket;
                tem.Id = onlineTickets.FirstOrDefault(q => q.Ticketnumber == ticket.Ticketnumber).Id;
                await client.PutAsJsonAsync("/api/Ticket/updateticket", tem);
            }
        }
    }
}
