using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

public static class aaronMetrics{
    public static readonly string meterName = "aaronsMeterForTickets";
        // Custom metrics for the application
    public static Meter aaronMeter = new Meter(meterName, "1.0.0");
    public static int reloadCount;
    public static int eventsMinusTicketAccess;
    public static int numberTicketReloads;
    public static Counter<int> ticketCreationCounter = aaronMeter.CreateCounter<int>("ticketCreations.count", description: "Counts the number of new tickets");
    public static UpDownCounter<int> unUpdatedTicketCounter = aaronMeter.CreateUpDownCounter<int>("unUpdatedTicketCounter", description: "Counts the number of new tickets minus any updated tickets");
    public static ObservableCounter<int> numberReloads = aaronMeter.CreateObservableCounter<int>("timesReloadMainPage", () => reloadCount, description: "This is called in the onisitialize function of the main page to count the number of times the page is loaded");
    public static ObservableUpDownCounter<int> numberEventTicket = aaronMeter.CreateObservableUpDownCounter<int>("TimesEventsMinusTimesTicketPages", () => eventsMinusTicketAccess, description: "when you load the event page, add one, when you load the ticket page minus one");
    public static ObservableGauge<int> observableGaugeTicket = aaronMeter.CreateObservableGauge<int>("observableGageTicket", GetPageLoads, description: "Counts number of times the tickets page is reloaded");
    public static Histogram<int> histogram = aaronMeter.CreateHistogram<int>("histogram", reloadCount.ToString());


    public static int ticketLoadGagePiece,eventLoadGagePiece,homeLoadGagePiece;
     static IEnumerable<Measurement<int>> GetPageLoads()
    {
        return new Measurement<int>[]
        {
            // pretend these measurements were read from a real queue somewhere
            new Measurement<int>(ticketLoadGagePiece),
            new Measurement<int>(eventLoadGagePiece),
            new Measurement<int>(homeLoadGagePiece),
        };
    }
}