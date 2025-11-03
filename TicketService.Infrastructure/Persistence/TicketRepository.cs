using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Aplication.Interfaces.Tickets;
using TicketService.Domain.Entities;

namespace TicketService.Infrastructure.Persistence
{
    public class TicketRepository: ITicketRepository

    {
        private readonly TicketDbContext _ticketDbContext;
        public TicketRepository(TicketDbContext ticketDbContext)
        {
            _ticketDbContext = ticketDbContext;
        }

        public async Task<List<EntTotalesTickets>> obtenerTotalesTicketAsync(string fcNumeroEmpleado)
        {
            return await _ticketDbContext.obtenerTotalesTicketAsync(fcNumeroEmpleado);
        }
    }
}
