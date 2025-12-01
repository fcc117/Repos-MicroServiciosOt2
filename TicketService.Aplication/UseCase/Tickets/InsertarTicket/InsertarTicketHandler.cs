using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Aplication.Interfaces.Tickets;
using TicketService.Aplication.UseCase.ObtenerTickets;
using TicketService.Domain.Entities;
using Utilities.Entities;

namespace TicketService.Aplication.UseCase.Tickets.InsertarTicket
{
    public class InsertarTicketHandler : IRequestHandler<InsertarTicketQuery, EntResultado>
    {
        private readonly ITicketRepository _ticketRepository;

        public InsertarTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<EntResultado> Handle(InsertarTicketQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado();
            try
            {
                var folio = await _ticketRepository.insertarNuevoTicketAsync(consulta.model);
                if(folio > 0)
                {
                    resultado.exito = true;
                    resultado.sValor = folio.ToString();
                }
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
