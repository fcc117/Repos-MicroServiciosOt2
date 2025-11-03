using LoginService.Aplication.Interfaces.Login;
using LoginService.Domain.Entities.Usuario;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;
using Utilities.Entities.Network;
using Utilities.Metodos;

namespace LoginService.Aplication.UseCases.Login
{
    public class CierreSesionHandler : IRequestHandler<CierreSesionQuery, EntResultado<int>>
    {
        private readonly ILoginAccesoRepository _loginAccesoRepository;
        private readonly InfoHostDns _infoHostDns;
        public CierreSesionHandler(ILoginAccesoRepository loginAccesoRepository, InfoHostDns infoHostDns)
        {
            _loginAccesoRepository = loginAccesoRepository;
            _infoHostDns = infoHostDns;
        }

        public async Task<EntResultado<int>> Handle(CierreSesionQuery request, CancellationToken cancellationToken)
        {
            EntResultado<int> result = new EntResultado<int>();
            try
            {
                var objInfoHostDns = _infoHostDns.ObtenerInfoDNS();

                EntLogAcceso objLogAcceso = new EntLogAcceso
                {
                    fcNumeroEmpleado = request.fcNumeroEmpleado,
                    fcOrigenIP = objInfoHostDns.info_HostAddress,
                    fcNavegador = objInfoHostDns.info_UserAgent,
                    fnTipoCierre = request.fnTipoCierre,
                    fcPCName = objInfoHostDns.info_MachineName,
                    fcUserDomainName = objInfoHostDns.info_DomainName,
                    fcTipoAcceso = request.fcTipoAcceso,
                };
                result.data = await _loginAccesoRepository.insertaCierreSesionUsuarioAsync(objLogAcceso);
                if(result.data == 1)
                {
                    result.exito = true;
                    result.error = "";
                    result.data = int.Parse(request.fcNumeroEmpleado);
                }
                else
                {
                    result.exito = false;
                    result.error = "No se pudo cerrar la sesión.";
                }

            }
            catch (Exception ex)
            {
                result.data = 0;
                result.error = ex.ToString();
                result.exito = null;
            }

            return result;
        }
    }
}
