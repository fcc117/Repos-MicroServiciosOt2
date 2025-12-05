using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Domain.Entities;
using TicketService.Domain.Entities.Catalogo;

namespace TicketService.Infrastructure.Persistence.Catalogo
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
        {

        }

        public DbSet<EntCatalogo> entCatalogo { get; set; }
        public DbSet<EntCeco> entCeco { get; set; }
        public DbSet<EntAuditor> entAuditor { get; set; }
        public async Task<List<EntCatalogo>> obtenerAreaServicio()
        {
            return await entCatalogo.FromSqlRaw("EXEC dbo.Tickets_catalogos_obtener_areas").ToListAsync();
        }

        public async Task<List<EntCatalogo>> obtenerTipoSolicitud(int idArea)
        {
            return await entCatalogo.FromSqlInterpolated($"EXEC dbo.tickets_catalogos_obtener_tipos_de_requerimiento {idArea}").ToListAsync();
        }
        public async Task<List<EntCatalogo>> obtenerUnidadNegocio(int idArea, int idSolicitud)
        {
            return await entCatalogo.FromSqlInterpolated($"EXEC dbo.tickets_catalogos_obtener_unidades_de_negocio_por_filtros {idArea}, {idSolicitud}").ToListAsync();
        }
        public async Task<List<EntCatalogo>> obtenerCatalogosVarios(int opc, int idParam, string nombreParam)
        {
            return await entCatalogo.FromSqlInterpolated($"EXEC dbo.sp_tickets_catalogos_nuevo_detalle {opc}, {idParam}, {nombreParam}").ToListAsync();
        }
        public async Task<List<EntCatalogo>> obtenerReferente(int idArea, int idSolicitud, int idUnidadNegocio, int estatus)
        {
            return await entCatalogo.FromSqlInterpolated($"EXEC dbo.Tickets_catalogos_obtener_referente_a_aux {idArea}, {idSolicitud}, {idUnidadNegocio}, {estatus}").ToListAsync();
        }

        public async Task<List<EntCeco>> obtenerCeco()
        {
            return await entCeco.FromSqlRaw("EXEC dbo.Tickets_catalogos_centros_de_costo_cobro").ToListAsync();
        }
        public async Task<List<EntAuditor>> obtenerAuditores(string busqueda)
        {
            return await entAuditor.FromSqlInterpolated($"EXEC dbo.Tickets_catalogos_obtener_auditores {busqueda}").ToListAsync();
        }
        public async Task<List<EntCatalogo>> obtenerVerTickets(string fcNumeroEmpleado)
        {
            return await entCatalogo.FromSqlInterpolated($"EXEC dbo.spConsOT2VerTickets {fcNumeroEmpleado}").ToListAsync();
        }
        public async Task<List<EntCatalogo>> obtenerEstatus()
        {
            return await entCatalogo.FromSqlRaw("EXEC dbo.tickets_catalogos_obtener_estatus").ToListAsync();
        }
        public async Task<List<EntCatalogo>> obtenerAntiguedad()
        {
            return await entCatalogo.FromSqlRaw("EXEC dbo.spConsOT2Antiguedad").ToListAsync();
        }
    }
    
}
