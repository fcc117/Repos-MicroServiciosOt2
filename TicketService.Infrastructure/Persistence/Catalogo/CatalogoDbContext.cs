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

        public async Task<List<EntCatalogo>> obtenerAreaServicio()
        {
            return await entCatalogo.FromSqlRaw("EXEC dbo.Tickets_catalogos_obtener_areas").ToListAsync();
        }

        public async Task<List<EntCatalogo>> obtenerTipoSolicitud(int idArea)
        {
            return await entCatalogo.FromSqlInterpolated($"EXEC dbo.tickets_catalogos_obtener_tipos_de_requerimiento {idArea}").ToListAsync();
        }
        public async Task<List<EntCatalogo>> obtenerUnidadNegocio(int idArea, int idRequerimietno)
        {
            return await entCatalogo.FromSqlInterpolated($"EXEC dbo.tickets_catalogos_obtener_tipos_de_requerimiento {idArea}, {idRequerimietno}").ToListAsync();
        }
        public async Task<List<EntCatalogo>> obtenerCatalogosVarios(int opc, int idParam, string nombreParam)
        {
            return await entCatalogo.FromSqlInterpolated($"EXEC dbo.sp_tickets_catalogos_nuevo_detalle {opc}, {idParam}, {nombreParam}").ToListAsync();
        }
    }
}
