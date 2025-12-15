using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Domain.Entities;
using Utilities.Entities;

namespace TicketService.Aplication.UseCase.Tickets.DetalleTicket
{
    public class ObtenerDetalleTicketQuery : IRequest<EntResultado<EntDetalleTicket>>
    {
        public int folio { get; set; }

    }
}
