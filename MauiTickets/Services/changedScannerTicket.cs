using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketLibrary.Data;
using TicketLibrary.Services;

namespace MauiTickets.Services
{
    public class changedScannerTicket
    {
        public changedScannerTicket(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }
        private readonly ITicketService ticketService;
        public string errorMessage { get; set; }
        public string sucessMessage { get; set; }
        public async Task changeScannedTicket(Ticket t, int eventId)
        {
            if (t is null)
            {
                errorMessage = "This is not a valid qr code for events";
            }
            else if (await TicketMatchesEvent(t, eventId))
            {
                if (!(bool)t.IsScanned)
                {
                    t.IsScanned = true;
                    await ticketService.UpdateATicket(t);
                    errorMessage = "";
                    sucessMessage = "Successfully scanned the ticket";
                }
                else
                {
                    sucessMessage = "";
                    errorMessage = "Your ticket has already been scanned!";
                }
            }
            else
            {
                sucessMessage = "";
                errorMessage = "Your ticket doesn't match this event!";
            }
        }
        public async Task<bool> TicketMatchesEvent(Ticket t, int eventId) => t.EventId.Equals(eventId);
    }
}
