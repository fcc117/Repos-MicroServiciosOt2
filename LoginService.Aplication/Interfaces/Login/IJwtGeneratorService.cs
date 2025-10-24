using LoginService.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities.Token;

namespace LoginService.Aplication.Interfaces.Login
{
    public interface IJwtGeneratorService
    {
        public string generaToken(EntUsuario usuario);
        public string generaRefreshToken(int fcNumeroEmpleado);
    }
}
