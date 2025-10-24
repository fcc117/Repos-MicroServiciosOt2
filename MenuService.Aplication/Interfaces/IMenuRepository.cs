using MenuService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Aplication.Interfaces
{
    public interface IMenuRepository
    {
        Task<List<EntMenu>> ObtenerMenuAsync(string fcNumeroEmpleado);

    }
}
