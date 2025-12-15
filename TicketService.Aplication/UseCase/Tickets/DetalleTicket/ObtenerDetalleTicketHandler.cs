using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Aplication.Interfaces.Tickets;
using TicketService.Aplication.UseCase.Tickets.ObtenerListaTickets;
using TicketService.Domain.Entities;
using Utilities.Entities;

namespace TicketService.Aplication.UseCase.Tickets.DetalleTicket
{
    public class ObtenerDetalleTicketHandler :IRequestHandler<ObtenerDetalleTicketQuery, EntResultado<EntDetalleTicket>>
    {
        private readonly ITicketRepository _ticketRepository;

        public ObtenerDetalleTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<EntResultado<EntDetalleTicket>> Handle(ObtenerDetalleTicketQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntDetalleTicket>();
            var entDetalle = new EntDetalleTicket();
            try
            {

                entDetalle = await _ticketRepository.obtenerDetalleGeneral(consulta.folio);
                resultado.exito = true;
                resultado.data = entDetalle;
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
