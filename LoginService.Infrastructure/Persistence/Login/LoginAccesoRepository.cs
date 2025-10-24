using LoginService.Aplication.Interfaces.Login;
using LoginService.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Infrastructure.Persistence.Log
{
    public class LoginAccesoRepository : ILoginAccesoRepository
    {
        private readonly LoginAccesoDbContext _dbContext;
        public LoginAccesoRepository(LoginAccesoDbContext context)
        {
            _dbContext = context;
        }


        public async Task<EntUsuario?> consultaExistenciaUsuarioAsync(string fcNumeroEmpleado)
        {
            return await _dbContext.consultaExistenciaUsuarioAsync(fcNumeroEmpleado);
        }

        public async Task<List<EntRoles>> consultaRolesAsync()
        {
            return await _dbContext.consultaRolesAsync();
        }
        public async Task<string> consultaAccesoUsuarioAsync(EntLogAcceso model)
        {
            return await _dbContext.consultaAccesoUsuarioAsync(model);
        }
        public async Task<int> insertaCierreSesionUsuarioAsync(EntLogAcceso model)
        {
            return await _dbContext.insertaCierreSesionUsuarioAsync(model);
        }

        public async Task<List<EntRolesUsuario>> consultaRolesUsuarioAsync(string fcNumeroEmpleado)
        {
            return await _dbContext.consultaRolesUsuarioAsync(fcNumeroEmpleado);
        }
    }
}
