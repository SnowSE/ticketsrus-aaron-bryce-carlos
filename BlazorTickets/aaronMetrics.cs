using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

public static class aaronMetrics{
    public static readonly string meterName = "aaronsMeterForTickets";
        // Custom metrics for the application
    public static Meter aaronMeter = new Meter(meterName, "1.0.0");
    public static Counter<int> ticketCreationCounter = aaronMeter.CreateCounter<int>("ticketCreations.count", description: "Counts the number of new tickets");
    public static UpDownCounter<int> unUpdatedTicketCounter = aaronMeter.CreateUpDownCounter<int>("unUpdatedTicketCounter", description: "Counts the number of new tickets minus any updated tickets");

}