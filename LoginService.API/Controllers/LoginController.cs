using LoginService.API.Models.Login;
using LoginService.Aplication.UseCases.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Utilities.Entities;

namespace LoginService.API.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("InicioSesion")]
        public async Task<IActionResult> InicioSesion([FromBody] LoginUserRequest request)
        {

            var result = new EntResultado();

            string dia = ((int)System.DateTime.Now.Day).ToString().PadLeft(2, '0');

            if (request.Password == "usr" + dia)
            {
                result = await _mediator.Send(new LoginQuery { fcNumeroEmpleado = request.UserName, fcPassword = request.Password, fcUserAgent = HttpContext.Request.Headers["User-Agent"].ToString() });
                if (result.exito == null)
                {
                    return BadRequest(result);
                }
                else
                {
                    return Ok(result);
                }
            }
            else
            {
                result.error = "Usuario o contraseña incorrectos.";
                result.exito = false;
                result.codeError = "-1";

                return Ok(result);
            }
        }

        [HttpPost("InicioSesionExistente")]
        public async Task<IActionResult> InicioSesionExistente([FromBody] LoginUserRequest request)
        {

            var result = new EntResultado();

            result = await _mediator.Send(new LoginQuery { fcNumeroEmpleado = request.UserName, fcPassword = request.Password, fcUserAgent = HttpContext.Request.Headers["User-Agent"].ToString() });
            if (result.exito == null)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost("CierreSesion")]
        public async Task<IActionResult> CierreSesion([FromBody] CierreSesionRequest request)
        {
            var result = new EntResultado();
            result = await _mediator.Send(new CierreSesionQuery { fcNumeroEmpleado = request.fcNumeroEmpleado, fcTipoAcceso = request.fcTipoAcceso, fnTipoCierre = request.fnTipoCierre });
            if (result.exito == null)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
