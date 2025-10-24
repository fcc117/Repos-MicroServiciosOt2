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
    public class ObtenerInfoSamlQuery : IRequest<EntResultado<EntUsuario>>
    {

    }
}
