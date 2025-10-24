using MenuService.Aplication.Interfaces;
using MenuService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Infrastructure.Persistence
{
    public class MenuRepository: IMenuRepository
    {
        private readonly MenuDbContext _dbContext;
        public MenuRepository(MenuDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<EntMenu>> ObtenerMenuAsync(string fcNumeroEmpleado)
        {
            return await Task.Run(() => _dbContext.ObtenerMenuAsync(fcNumeroEmpleado));
        }
    }
}
