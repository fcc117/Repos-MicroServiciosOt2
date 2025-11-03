using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Domain.Entities;
using Utilities.Entities;

namespace TicketService.Aplication.UseCase.ObtenerTickets
{
    public class ObtenerTotalesTicketQuery:IRequest<EntResultado<EntTotalesTickets>>
    {
        public string fcNumeroEmpleado { get; set; }
    }
}
