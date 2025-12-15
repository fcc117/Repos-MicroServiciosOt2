using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketService.API.Models.Ticket;
using TicketService.Aplication.UseCase.ObtenerTickets;
using TicketService.Aplication.UseCase.Tickets.DetalleTicket;
using TicketService.Aplication.UseCase.Tickets.InsertarTicket;
using TicketService.Aplication.UseCase.Tickets.ObtenerListaTickets;

namespace TicketService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ObtenerTotalesTicket")]
        public async Task<IActionResult> ObtenerMenu([FromBody] TotalesTicketRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerTotalesTicketQuery { fcNumeroEmpleado = request.fcNumeroEmpleado });
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpPost("InsertarTicket")]
        public async Task<IActionResult> InsertarTicket([FromBody] TicketRequest request)
        {
            var resultado = await _mediator.Send(new InsertarTicketQuery { model = request.model });
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpPost("ObtenerTickets")]
        public async Task<IActionResult> ObtenerTickets([FromBody] TicketsRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerTicketsQuery { model = request.model });
            if (resultado.exito == null)
            {
                return BadRequest(resultado);
            }
            else
            {
                return Ok(resultado);
            }
        }

        [HttpPost("ObtenerDetalleTicket")]
        public async Task<IActionResult> ObtenerDetalleTicket([FromBody] TicketDetalleRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerDetalleTicketQuery { folio = request.folio });
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
