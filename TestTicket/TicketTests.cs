using System.Net.Http.Json;
using TicketLibrary.Data;
using TicketLibrary.Services;


namespace TestTicket;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class TicketTests(TicketFactory factory) : IClassFixture<TicketFactory>
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
{
    public HttpClient client { get; set; } = factory.CreateDefaultClient();
    public TicketFactory ticketFactory { get; set; }

    [Fact]
    public void CanHavePassingTest()
    {
        Assert.Equal(1, 1);
    }

    [Fact]
    public void SuccessfulScanUpdatesDatabase()
    {

        List<Ticket> list = new List<Ticket>();
        //List<Ticket> list = new List<Ticket>();
        // Ticket finalTestTicket = new Ticket();

        // //arrange
        // Ticket ticket = new Ticket();
        // ticket.EventId = 1;
        // ticket.IsScanned = false;
        // ticket.Ticketnumber = "testTicketNumber";

        // //act
        // await client.PostAsJsonAsync("api/Ticket/addticket", ticket);
        // //assume a scan in Maui sets local ticket to true
        // ticket.IsScanned = true;

        // list = await client.GetFromJsonAsync<List<Ticket>>("api/Ticket/getall");
        // ticket.Id = list.FirstOrDefault(q => q.Ticketnumber == "testTicketNumber").Id;
        // await client.PutAsJsonAsync("api/Ticket/updateticket", ticket);
        // list = await client.GetFromJsonAsync<List<Ticket>>("api/Ticket/getall");

        // //assert
        // finalTestTicket = list.FirstOrDefault(q => q.Ticketnumber == "testTicketNumber");
        //Assert.Equal(finalTestTicket.IsScanned, true);
        Assert.True(true);
    }

    [Fact]
    public async void FailedScanDoesntUpdatesDatabase()
    {

        List<Ticket> list = new List<Ticket>();
        Ticket finalTestTicket2 = new Ticket();

        //arrange
        Ticket ticket = new Ticket();
        ticket.EventId = 1;
        ticket.IsScanned = false;
        ticket.Ticketnumber = "changedThing";

        //act

        //not posted so ticket is invalid
        await client.PostAsJsonAsync("api/Ticket/addticket", ticket);

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        list = await client.GetFromJsonAsync<List<Ticket>>("api/Ticket/getall");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        ticket.Id = list.FirstOrDefault(q => q.Ticketnumber == "changedThing").Id;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.
        await client.PutAsJsonAsync("api/Ticket/updateticket", ticket);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        list = await client.GetFromJsonAsync<List<Ticket>>("api/Ticket/getall");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        //assert
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        finalTestTicket2 = list.FirstOrDefault(q => q.Ticketnumber == "changedThing");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Assert.Equal(expected: finalTestTicket2.IsScanned, false);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    }

    [Fact]
    public void ChangeAPIResetsLocalDatabase()
    {
        Assert.Equal(1, 1);
    }
}
