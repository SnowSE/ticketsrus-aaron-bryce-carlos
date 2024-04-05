using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace BlazorTickets;

public static class bryceMetrics
{
    public static readonly string customMetric = "bryceMetric";

    public static int observableInt = 0;
    public static int observableUpDown = 0;

    //Regular Counter
    public static Meter Meter = new("customMetric", "1.0.0");
    public static Counter<int> hitCount = Meter.CreateCounter<int>("greetings.count");

    //UpDownCounter
    public static UpDownCounter<int> upDownCounter = Meter.CreateUpDownCounter<int>("upDownThingCount", "1.0.0");

    //Observable Counter
    public static ObservableCounter<int> observableCounter = Meter.CreateObservableCounter<int>("observableCounterCount", () => observableInt);

    //ObservableUpDownCounter
    public static ObservableUpDownCounter<int> observableUpDownCounter = Meter.CreateObservableUpDownCounter<int>("observableUpDownCount", () => observableUpDown);

    //ObservableGauge
    public static ObservableGauge<int> observableGauge = Meter.CreateObservableGauge<int>("observableGaugeCount", () => DateTime.Now.Second);

    //Histogram
    public static Histogram<int> histogram = Meter.CreateHistogram<int>("histogramCount", "1.0.0");

//to make the push work
}
