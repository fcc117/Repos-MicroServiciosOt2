using LoginService.Aplication.Interfaces.Login;
using LoginService.Aplication.Interfaces.Menu;
using LoginService.Aplication.Interfaces.Saml;
using LoginService.Aplication.UseCases.Dto;
using LoginService.Domain.Entities.Usuario;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;
using Utilities.Entities.Network;
using Utilities.Entities.Token;
using Utilities.Metodos;


namespace LoginService.Aplication.UseCases.Login
{
    public class LoginHandler : IRequestHandler<LoginQuery, EntResultado<EntUsuario>>
    {
        private readonly ILoginAccesoRepository _loginAccesoRepository;
        private readonly IMenuService _menuService;
        private readonly IJwtGeneratorService _jwtgenerator;
        private readonly EntJwt _jwtOpc;
        public LoginHandler(ILoginAccesoRepository loginAccesoRepository
            , IMenuService menuService
            , IJwtGeneratorService jwtgenerator
            , IOptions<EntJwt> jwtOpc
            )
        {
            _loginAccesoRepository = loginAccesoRepository;
            _menuService = menuService;
            _jwtgenerator = jwtgenerator;
            _jwtOpc = jwtOpc.Value;
        }
        public async Task<EntResultado<EntUsuario>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            EntResultado<EntUsuario> result = new EntResultado<EntUsuario>();
            EntUsuario? objUsuario = new EntUsuario();
            List<EntRoles> lstRoles = new List<EntRoles>();
            List<EntRolesUsuario> lstRolesUsr = new List<EntRolesUsuario>();
            List<MenuResponseDto> lstmenu = new List<MenuResponseDto>();
            string token = string.Empty;
            string refreshToken = string.Empty;
            try
            {
                InfoHostDns objInfo = new InfoHostDns();
                EntUInfoHostDns objInfoHostDns = objInfo.ObtenerInfoDNS();
                objUsuario = await _loginAccesoRepository.consultaExistenciaUsuarioAsync(request.fcNumeroEmpleado);
                if (objUsuario is not null)
                {
                    lstRolesUsr = await _loginAccesoRepository.consultaRolesUsuarioAsync(request.fcNumeroEmpleado);
                    //lstRoles = await _loginAccesoService.consultaRolesAsync();
                    if (lstRolesUsr.Count() > 0)
                    {
                        EntLogAcceso objLogAcceso = new EntLogAcceso
                        {
                            fcNumeroEmpleado = request.fcNumeroEmpleado
                            ,
                            fcOrigenIP = objInfoHostDns.info_HostAddress
                            ,
                            fcNavegador = request.fcUserAgent
                            ,
                            fcPCName = objInfoHostDns.info_MachineName
                            ,
                            fcUserDomainName = objInfoHostDns.info_DomainName
                            ,
                            fcTipoAcceso = "Inicio de sesión"
                        };

                        string valorSesion = await _loginAccesoRepository.consultaAccesoUsuarioAsync(objLogAcceso);
                        if (valorSesion == "Exito")
                        {
                            token = _jwtgenerator.generaToken(objUsuario);
                            refreshToken = _jwtgenerator.generaRefreshToken(objUsuario.fnNumeroEmpleado);
                            lstmenu = await _menuService.ObtenerMenuPorEmpleadoAsync(request.fcNumeroEmpleado, token);

                            result.objectlist = lstmenu.Cast<object>().ToList();
                            result.data = objUsuario;
                            result.exito = true;
                            result.error = valorSesion;
                            result.codeError = string.Empty;
                            result.accessToken = token;
                            result.expireIn = _jwtOpc.ExpiresMinutes;
                            result.refreshToken = refreshToken;

                        }
                        else
                        {
                            result.objectlist = null;
                            result.data = null;
                            result.exito = false;
                            result.codeError = "1";
                            result.error = "SesionExistente";
                            result.accessToken = "";
                            result.refreshToken = "";

                        }
                    }
                    else
                    {
                        result.objectlist = null;
                        result.data = null;
                        result.exito = false;
                        result.codeError = "2";
                        result.error = "PerfilNoAutorizado";
                        result.accessToken = "";
                        result.refreshToken = "";
                    }

                }
                else
                {
                    result.objectlist = null;
                    result.data = null;
                    result.exito = false;
                    result.codeError = "3";
                    result.error = "PerfilNoAutorizado";
                    result.accessToken = "";
                    result.refreshToken = "";
                }
            }
            catch (Exception ex)
            {
                result.objectlist = null;
                result.data = null;
                result.error = ex.ToString();
                result.exito = false;
                result.codeError = "4";
                result.accessToken = "";
                result.refreshToken = "";
            }
            return result;
        }
    }
}
