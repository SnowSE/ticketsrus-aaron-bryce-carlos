﻿using Microsoft.AspNetCore.Mvc;
using TicketLibrary.Services;
using TicketLibrary.Data;

namespace BlazorTickets.contollers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;
    public TicketController(ITicketService ticketService)
    { 
        _ticketService = ticketService;
    }

    [HttpGet("getall")]
    public async Task<IEnumerable<Ticket>> GetTicketsAsync()
    {
        return await _ticketService.GetAllTicketsAsync();
    }


}
