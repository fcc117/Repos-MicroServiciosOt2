using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Aplication.Interfaces.Catalogo;
using TicketService.Domain.Entities.Catalogo;
using Utilities.Entities;

namespace TicketService.Aplication.UseCase.Catalogo
{
    public class ObtenerEstatusHandler : IRequestHandler<ObtenerEstatusQuery, EntResultado<EntCatalogo>>
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public ObtenerEstatusHandler(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }
        public async Task<EntResultado<EntCatalogo>> Handle(ObtenerEstatusQuery consulta,CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntCatalogo>();
            try
            {
                resultado.datalist = await _catalogoRepository.obtenerEstatus();
                resultado.exito = true;
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
