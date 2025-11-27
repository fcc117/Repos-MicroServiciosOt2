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
    public class ObtenerCecoHandler : IRequestHandler<ObtenerCecoQuery, EntResultado<EntCeco>>
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public ObtenerCecoHandler(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public async Task<EntResultado<EntCeco>> Handle(ObtenerCecoQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntCeco>();
            try
            {
                resultado.datalist = await _catalogoRepository.obtenerCeco();
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
