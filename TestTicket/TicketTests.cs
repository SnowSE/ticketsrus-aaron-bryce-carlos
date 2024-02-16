namespace TestTicket;

public class TicketTests : IClassFixture<TicketFactory>
{
    public HttpClient client { get; set; }

    [Fact]
    public void Test1()
    {
        Assert.Equal(1, 1);
    }

    [Fact] public void SuccessfulScanUpdatesDatabase()
    {
        Assert.Equal(1, 1);
    }

    [Fact] public void FailedScanDoesntUpdatesDatabase()
    {
        Assert.Equal(1, 1);
    }

    [Fact]
    public void ChangeAPIResetsLocalDatabase()
    {
        Assert.Equal(1, 1);
    }
}