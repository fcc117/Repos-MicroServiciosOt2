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
    public class ObtenerAuditoresHandler : IRequestHandler<ObtenerAuditoresQuery, EntResultado<EntAuditor>>
    {
        private readonly ICatalogoRepository _catalogoRepository;

        public ObtenerAuditoresHandler(ICatalogoRepository catalogoRepository)
        {
            _catalogoRepository = catalogoRepository;
        }

        public async Task<EntResultado<EntAuditor>> Handle(ObtenerAuditoresQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntAuditor>();
            try
            {
                resultado.datalist = await _catalogoRepository.obtenerAuditores(consulta.busqueda);
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
