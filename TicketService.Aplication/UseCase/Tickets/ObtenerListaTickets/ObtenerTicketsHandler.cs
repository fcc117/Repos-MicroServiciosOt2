using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Aplication.Interfaces.Tickets;
using TicketService.Aplication.UseCase.Tickets.InsertarTicket;
using TicketService.Domain.Entities;
using Utilities.Entities;

namespace TicketService.Aplication.UseCase.Tickets.ObtenerListaTickets
{
    public class ObtenerTicketsHandler : IRequestHandler<ObtenerTicketsQuery, EntResultado<EntTickets>>
    {
        private readonly ITicketRepository _ticketRepository;

        public ObtenerTicketsHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<EntResultado<EntTickets>> Handle(ObtenerTicketsQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntTickets>();
            var lstTickets = new List<EntTickets>();
            try
            {

                lstTickets = await _ticketRepository.obtenerTickets(consulta.model);
                resultado.exito = true;
                resultado.datalist = lstTickets;
            }
            catch (Exception ex)
            {
                resultado.exito = false;
                resultado.error = ex.Message;
            }
            return resultado;
        }
    }
}
