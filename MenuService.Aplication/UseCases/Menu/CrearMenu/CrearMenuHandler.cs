using MediatR;
using MenuService.Aplication.Interfaces;
using MenuService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace MenuLayoutService.Aplication.UseCases.Menu.CrearMenu
{
    public class CrearMenuHandler : IRequestHandler<CrearMenuCommand, EntResultado<EntMenu>>
    {
        private readonly IMenuRepository _repositorioMenu;
        public CrearMenuHandler(IMenuRepository repositorioMenu)
        {
            _repositorioMenu = repositorioMenu;
        }

        public async Task<EntResultado<EntMenu>> Handle(CrearMenuCommand comando, CancellationToken cancellationToken)
        {
            var resultado = new EntResultado<EntMenu>();
            try
            {
                var menu = new EntMenu
                {
                    fiMenuPadre = comando.fiMenuPadre
                    // Asigna otras propiedades
                };


                resultado.exito = true;
                resultado.data = menu;

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


