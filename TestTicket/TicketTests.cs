namespace TestTicket;

public class TicketTests : IClassFixture<TicketFactory>
{
    public HttpClient client { get; set; }

    [Fact]
    public void Test1()
    {
        Assert.Equal(1, 1);
    }
}