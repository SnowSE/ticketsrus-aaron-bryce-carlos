using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace BlazorTickets;

public static class bryceMetrics
{
    public static readonly string customMetric = "bryceMetric";

    public static Meter Meter = new("customMetric", "1.0.0");
    public static Counter<int> hitCount = Meter.CreateCounter<int>("greetings.count");

}
