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
    public class ObtenerReferenteHandler : IRequestHandler<ObtenerReferenteQuery, EntResultado<EntCatalogo>>
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public ObtenerReferenteHandler(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public async Task<EntResultado<EntCatalogo>> Handle(ObtenerReferenteQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntCatalogo>();
            try
            {
                resultado.datalist = await _catalogoRepository.obtenerReferente(consulta.idArea,consulta.idSolicitud, consulta.idUnidadNegocio, consulta.estatus);
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
