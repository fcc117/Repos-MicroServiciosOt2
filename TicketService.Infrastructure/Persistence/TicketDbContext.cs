using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Domain.Entities;

namespace TicketService.Infrastructure.Persistence
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {

        }
        public DbSet<EntTotalesTickets> entTotalesTickets { get; set; }

        public async Task<List<EntTotalesTickets>> obtenerTotalesTicketAsync(string fcNumeroEmpleado)
        {
            if (string.IsNullOrWhiteSpace(fcNumeroEmpleado))
                return new List<EntTotalesTickets>();
            return await entTotalesTickets.FromSqlInterpolated($"EXEC dbo.spConsOT2TotalTickets {fcNumeroEmpleado}").ToListAsync();
            
        }

    }
}
