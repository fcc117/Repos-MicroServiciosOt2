using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketService.API.Models.Catalogo;
using TicketService.API.Models.Ticket;
using TicketService.Aplication.UseCase.Catalogo;
using TicketService.Aplication.UseCase.ObtenerTickets;

namespace TicketService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CatalogoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ObtenerAreaServicio")]
        public async Task<IActionResult> ObtenerAreaServicio()
        {
            var resultado = await _mediator.Send(new ObtenerAreaServicioQuery { });
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpPost("ObtenerTipoSolicitud")]
        public async Task<IActionResult> ObtenerTipoSolicitud([FromBody] TipoSolicitudRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerTipoSolicitudQuery { idArea = request.idArea });
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpPost("ObtenerUnidadNegocio")]
        public async Task<IActionResult> ObtenerUnidadNegocio([FromBody] UnidadNegocioRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerUnidadNegocioQuery { idArea = request.idArea, idSolicitud = request.idSolicitud });
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpPost("ObtenerCatalogoVarios")]
        public async Task<IActionResult> ObtenerCatalogoVarios([FromBody] CatalogoVariosRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerCatalogosVariosQuery { opc = request.opc, idParam = request.idParam, nombreParam = request.nombreParam });
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }


        [HttpPost("ObtenerReferente")]
        public async Task<IActionResult> ObtenerReferente([FromBody] ReferenteRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerReferenteQuery { idArea = request.idArea, idSolicitud = request.idSolicitud, idUnidadNegocio = request.idUnidadNegocio , estatus = request.estatus});
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpPost("ObtenerCeco")]
        public async Task<IActionResult> ObtenerCeco()
        {
            var resultado = await _mediator.Send(new ObtenerCecoQuery { });
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpPost("ObtenerAuditores")]
        public async Task<IActionResult> ObtenerAuditores([FromBody] AuditoresRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerAuditoresQuery { busqueda = request.busqueda});
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }
    }
}
