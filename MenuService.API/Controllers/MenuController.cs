using MediatR;
using MenuService.API.Models.Menu;
using MenuService.Aplication.UseCases.Menu.ObtenerMenu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ObtenerMenu")]
        public async Task<IActionResult> ObtenerMenu([FromBody] MenuRequest request)
        {
            var resultado = await _mediator.Send(new ObtenerMenuQuery { fcNumeroEmpleado = request.fcNumeroEmpleado });
            if (resultado.exito)
            {
                return Ok(resultado); 
            }
            else
            {
                return BadRequest(resultado); 
            }
        }
    }
}
