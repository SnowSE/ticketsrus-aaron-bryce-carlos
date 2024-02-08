using System;
using System.Collections.Generic;

namespace TicketLibrary.Data;

public partial class Event
{
    public int Id { get; set; }

    public string? EventName { get; set; }

    public DateOnly? DateOfEvent { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
