using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Domain.Entities;
using TicketService.Domain.Entities.Catalogo;

namespace TicketService.Aplication.Interfaces.Tickets
{
    public interface ITicketRepository
    {
        Task<List<EntTotalesTickets>> obtenerTotalesTicketAsync(string fcNumeroEmpleado);
        Task<int?> insertarNuevoTicketAsync(EntTicket model);
        Task<List<EntTickets>> obtenerTickets(EntTicketParam model);
        Task<EntDetalleTicket> obtenerDetalleGeneral(int folio);


    }
}
