using LoginService.Aplication.Interfaces.Saml;
using LoginService.Domain.Entities.Usuario;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.Entities;

namespace LoginService.Aplication.UseCases.Saml.ObtenerInfo
{
    public class ObtenerInfoSamlHandler : IRequestHandler<ObtenerInfoSamlQuery, EntResultado<EntUsuario>>
    {
         private readonly ISamlService _samlService;
        public ObtenerInfoSamlHandler(ISamlService samlService)
        {
            _samlService = samlService;
        }

        public async Task<EntResultado<EntUsuario>> Handle(ObtenerInfoSamlQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = await _samlService.DevuelveParametrosOkta();
            return resultado;
        }


    }
}
