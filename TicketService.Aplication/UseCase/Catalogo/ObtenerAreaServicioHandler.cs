using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Aplication.Interfaces.Catalogo;
using TicketService.Aplication.Interfaces.Tickets;
using TicketService.Aplication.UseCase.ObtenerTickets;
using TicketService.Domain.Entities;
using TicketService.Domain.Entities.Catalogo;
using Utilities.Entities;

namespace TicketService.Aplication.UseCase.Catalogo
{
    public class ObtenerAreaServicioHandler: IRequestHandler<ObtenerAreaServicioQuery, EntResultado<EntCatalogo>>
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public ObtenerAreaServicioHandler(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public async Task<EntResultado<EntCatalogo>> Handle(ObtenerAreaServicioQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntCatalogo>();
            var lstAreaServicio = new List<EntCatalogo>();
            try
            {
                resultado.datalist = await _catalogoRepository.obtenerAreaServicio();
                resultado.exito = true;
                resultado.datalist = lstAreaServicio;
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
