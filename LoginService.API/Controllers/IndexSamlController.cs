using LoginService.Aplication.UseCases.Saml.ObtenerInfo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LoginService.API.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class IndexSamlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndexSamlController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("IndexSaml")]
        public async Task<IActionResult> IndexSaml()
        {
            var resultado = await _mediator.Send(new ObtenerInfoSamlQuery());
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
