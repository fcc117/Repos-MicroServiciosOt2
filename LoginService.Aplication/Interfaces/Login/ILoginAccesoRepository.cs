using LoginService.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Aplication.Interfaces.Login
{
    public interface ILoginAccesoRepository
    {
        Task<EntUsuario?> consultaExistenciaUsuarioAsync(string fcNumeroEmpleado);
        Task<List<EntRoles>> consultaRolesAsync();
        Task<string> consultaAccesoUsuarioAsync(EntLogAcceso model);
        Task<int> insertaCierreSesionUsuarioAsync(EntLogAcceso model);
        Task<List<EntRolesUsuario>> consultaRolesUsuarioAsync(string fnNumeroEmpleado);

    }
}
