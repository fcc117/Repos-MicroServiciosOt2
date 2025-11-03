using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Aplication.Interfaces.Tickets;
using TicketService.Domain.Entities;
using Utilities.Entities;

namespace TicketService.Aplication.UseCase.ObtenerTickets
{
    public class ObtenerTotalesTicketHandler:IRequestHandler<ObtenerTotalesTicketQuery, EntResultado<EntTotalesTickets>>
    {
        private readonly ITicketRepository _ticketRepository;

        public ObtenerTotalesTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<EntResultado<EntTotalesTickets>> Handle(ObtenerTotalesTicketQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntTotalesTickets>();
            var lstTotalesTicket = new List<EntTotalesTickets>();
            try
            {
                lstTotalesTicket = await _ticketRepository.obtenerTotalesTicketAsync(consulta.fcNumeroEmpleado);
                resultado.exito = true;
                resultado.datalist = lstTotalesTicket;
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
