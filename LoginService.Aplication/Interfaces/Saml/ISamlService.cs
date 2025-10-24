using LoginService.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.Entities;

namespace LoginService.Aplication.Interfaces.Saml
{
    public interface ISamlService
    {
        Task<EntResultado<EntUsuario>> DevuelveParametrosOkta();
    }
}
