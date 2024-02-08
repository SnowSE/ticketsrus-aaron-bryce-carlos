using System;
using System.Collections.Generic;

namespace TicketLibrary.Data;

public partial class Ticket
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public string? UserEmail { get; set; }

    public bool? IsScanned { get; set; }

    public virtual Event? Event { get; set; }
}
