using MenuService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Infrastructure.Persistence
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options)
        {

        }
        public DbSet<EntMenu> EntMenus { get; set; }

        public List<EntMenu> ObtenerMenuAsync(string fcNumeroEmpleado) =>
       EntMenus.FromSqlInterpolated($"EXEC dbo.spConsOT2MenuUsuario {fcNumeroEmpleado}").ToList();

    }
}
