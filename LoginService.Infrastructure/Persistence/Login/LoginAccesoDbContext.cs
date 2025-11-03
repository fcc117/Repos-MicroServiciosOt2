using LoginService.Domain.Entities.Usuario;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoginService.Infrastructure.Persistence.Log
{
    public class LoginAccesoDbContext : DbContext
    {

        public LoginAccesoDbContext(DbContextOptions<LoginAccesoDbContext> options) : base(options)
        {


        }

        public DbSet<EntUsuario> entUsuario { get; set; }
        public DbSet<EntRoles> entRoles { get; set; }
        public DbSet<EntRolesUsuario> entRolesUsuario { get; set; }

        public async Task<EntUsuario?> consultaExistenciaUsuarioAsync(string fcNumeroEmpleado)
        {
            if (string.IsNullOrWhiteSpace(fcNumeroEmpleado))
                return null;

            var result = await entUsuario.FromSqlInterpolated($"EXEC dbo.spConsOT2EstructuraUsuario {fcNumeroEmpleado}").ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<List<EntRoles>> consultaRolesAsync()
        {
            return await entRoles.FromSqlRaw("EXEC dbo.spConsOT2Roles").ToListAsync();
        }

        public async Task<List<EntRolesUsuario>> consultaRolesUsuarioAsync(string fcNumeroEmpleado)
        {
            return await entRolesUsuario.FromSqlInterpolated($"EXEC dbo.spConsOT2RolesUsuario {fcNumeroEmpleado}").ToListAsync();
        }

        public async Task<string> consultaAccesoUsuarioAsync(EntLogAcceso model)
        {
            var result = await Database.SqlQueryRaw<string>("EXEC dbo.spConsOT2SesionUsuario  @p0, @p1, @p2, @p3, @p4, @p5",
                model.fcNumeroEmpleado, model.fcOrigenIP, model.fcNavegador, model.fcPCName, model.fcUserDomainName, model.fcTipoAcceso).ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> insertaCierreSesionUsuarioAsync(EntLogAcceso model)
        {
            var result = await Database.SqlQueryRaw<int>("EXEC dbo.spUpdOT2CambiaEstatusSesionUsuario @p0, @p1, @p2, @p3, @p4, @p5, @p6",
          model.fcNumeroEmpleado,model.fcOrigenIP,model.fcNavegador,model.fnTipoCierre,model.fcPCName, model.fcUserDomainName, model.fcTipoAcceso).ToListAsync();
            return result.FirstOrDefault();
        }

    }
}
