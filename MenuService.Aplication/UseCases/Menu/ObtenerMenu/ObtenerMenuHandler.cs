using MediatR;
using MenuService.Aplication.Interfaces;
using MenuService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace MenuService.Aplication.UseCases.Menu.ObtenerMenu
{
    public class ObtenerMenuHandler : IRequestHandler<ObtenerMenuQuery, EntResultado<EntMenu>>
    {
        private readonly IMenuRepository _repositorioMenu;
        public ObtenerMenuHandler(IMenuRepository repositorioMenu)
        {
            _repositorioMenu = repositorioMenu;
        }
        public async Task<EntResultado<EntMenu>> Handle(ObtenerMenuQuery consulta, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntMenu>();
            var lstmenu = new List<EntMenu>();
            try
            {
                lstmenu = await _repositorioMenu.ObtenerMenuAsync(consulta.fcNumeroEmpleado);
                resultado.exito = true;
                resultado.datalist = lstmenu;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.exito = false;
                resultado.error = ex.Message;
                return resultado;
            }
        }
    }
}
