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
                if (result.exito)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
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
    }
}
