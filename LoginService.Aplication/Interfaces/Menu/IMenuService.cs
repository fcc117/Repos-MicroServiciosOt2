using LoginService.Aplication.UseCases.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Aplication.Interfaces.Menu
{
    public interface IMenuService
    {
        Task<List<MenuResponseDto>> ObtenerMenuPorEmpleadoAsync(string fcNumeroEmpleado, string token);
    }
}
