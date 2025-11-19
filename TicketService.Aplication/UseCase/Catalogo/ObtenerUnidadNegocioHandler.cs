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
    internal class ObtenerUnidadNegocioHandler : IRequestHandler<ObtenerUnidadNegocioQuery, EntResultado<EntCatalogo>>
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public ObtenerUnidadNegocioHandler(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public async Task<EntResultado<EntCatalogo>> Handle(ObtenerUnidadNegocioQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntCatalogo>();
            var lstunidadnegocio = new List<EntCatalogo>();
            try
            {
                resultado.datalist = await _catalogoRepository.obtenerUnidadNegocio(consulta.idArea, consulta.idRequerimiento);
                resultado.exito = true;
                resultado.datalist = lstunidadnegocio;
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
