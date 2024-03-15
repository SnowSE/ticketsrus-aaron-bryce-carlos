using System.Diagnostics;

namespace BlazorTickets;

public static class bryceTrace
{
        public static readonly string serviceName1 = "Bryce First Trace";
        public static readonly string serviceName2 = "Bryce Second Trace";
        public static readonly ActivitySource MyActivitySource1 = new(serviceName1);
        public static readonly ActivitySource MyActivitySource2 = new(serviceName2);
}
