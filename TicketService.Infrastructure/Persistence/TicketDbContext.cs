using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Domain.Entities;
using TicketService.Domain.Entities.Catalogo;

namespace TicketService.Infrastructure.Persistence
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {

        }
        public DbSet<EntTotalesTickets> entTotalesTickets { get; set; }
        public DbSet<EntTickets> entTickets { get; set; }


        public async Task<List<EntTotalesTickets>> obtenerTotalesTicketAsync(string fcNumeroEmpleado)
        {
            if (string.IsNullOrWhiteSpace(fcNumeroEmpleado))
                return new List<EntTotalesTickets>();
            return await entTotalesTickets.FromSqlInterpolated($"EXEC dbo.spConsOT2TotalTickets {fcNumeroEmpleado}").ToListAsync();

        }

        public async Task<int?> insertarNuevoTicketAsync(EntTicket model)
        {

            await Database.OpenConnectionAsync();
            using var command = Database.GetDbConnection().CreateCommand();
            command.CommandText = "dbo.spInsOT2NuevoTicket";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@id_area", SqlDbType.Int) { Value = model.id_area });
            command.Parameters.Add(new SqlParameter("@id_tipo_requerimiento", SqlDbType.Int) { Value = model.id_tipo_requerimiento });
            command.Parameters.Add(new SqlParameter("@id_unidad_negocio", SqlDbType.Int) { Value = model.id_unidad_negocio });
            command.Parameters.Add(new SqlParameter("@folio_honestel", SqlDbType.Int) { Value = model.folio_honestel });
            command.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.Text) { Value = model.descripcion });
            command.Parameters.Add(new SqlParameter("@usuario_llave_maestra_creacion", SqlDbType.VarChar, 20) { Value = model.usuario_llave_maestra_creacion });
            command.Parameters.Add(new SqlParameter("@centro_de_costos_cobro", SqlDbType.VarChar, 150) { Value = model.centro_de_costos_cobro });
            command.Parameters.Add(new SqlParameter("@folio_comercio", SqlDbType.Int) { Value = model.folio_comercio });
            command.Parameters.Add(new SqlParameter("@tipo_PSolicitud", SqlDbType.VarChar, 50) { Value = (object?)model.tipo_PSolicitud ?? DBNull.Value });
            command.Parameters.Add(new SqlParameter("@tipo_incidente", SqlDbType.VarChar, 100) { Value = (object?)model.tipo_incidente ?? DBNull.Value });
            command.Parameters.Add(new SqlParameter("@id_referente_a", SqlDbType.Int) { Value = model.id_referente_a });
            command.Parameters.Add(new SqlParameter("@listaConsultores", SqlDbType.VarChar, -1) { Value = model.listaConsultores });

            var dtable = new DataTable();
            dtable.Columns.Add("session_id", typeof(string));
            dtable.Columns.Add("nombre", typeof(string));
            dtable.Columns.Add("archivo", typeof(byte[]));
            dtable.Columns.Add("tamaño", typeof(int));
            dtable.Columns.Add("extension", typeof(string));

            foreach (var doc in model.listaDocumentos)
            {
                byte[] archivo = Convert.FromBase64String(doc.archivo);

                dtable.Rows.Add(
                    doc.folio,
                    doc.nombre,
                    archivo,
                    doc.tamaño,
                    doc.extension
                    
                );
            }
            var tableType = new SqlParameter("@listaDocumentos", SqlDbType.Structured)
            {
                TypeName = "dbo.TICKETS_TEMPORAL_ARCHIVOS_ADJUNTOS_TYPE",
                Value = dtable
            };
            command.Parameters.Add(tableType);

            var paramFolio = new SqlParameter("@folio", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(paramFolio);

            await command.ExecuteNonQueryAsync();

            return paramFolio.Value as int?;
        }

        public async Task<List<EntTickets>> obtenerTickets(EntTicketParam model)
        {
            return await entTickets.FromSqlInterpolated($@"EXEC dbo.Tickets_consulta_obtener_tickets 
                                                            {model.UsuarioLlaveMaestra},
                                                            {model.FolioTicket},
                                                            {model.AuditorSolicitante},
                                                            {model.AntiguedadRango},
                                                            {model.Antiguedad},
                                                            {model.FechaRegistroDesde},
                                                            {model.FechaRegistroHasta},
                                                            {model.IdEstatus},
                                                            {model.FechaCierreDesde},
                                                            {model.FechaCierreHasta},
                                                            {model.IdVerRegistros},
                                                            {model.IdArea}").ToListAsync();

        }
    }
}
