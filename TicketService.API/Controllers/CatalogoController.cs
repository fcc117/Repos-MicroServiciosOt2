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
        public async Task<IActionResult> ObtenerTipoSolicitud([FromBody] CatalogoRequest request)
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
        public async Task<IActionResult> ObtenerUnidadNegocio([FromBody] CatalogoRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerUnidadNegocioQuery { idArea = request.idArea, idRequerimiento = request.idRequerimiento });
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
        public async Task<IActionResult> ObtenerCatalogoVarios([FromBody] CatalogoRequest request)
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
    }
}
