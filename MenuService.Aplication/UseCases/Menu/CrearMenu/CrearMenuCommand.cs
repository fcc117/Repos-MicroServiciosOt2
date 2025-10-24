using MediatR;
using MenuService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace MenuLayoutService.Aplication.UseCases.Menu.CrearMenu
{
    public class CrearMenuCommand : IRequest<EntResultado<EntMenu>>
    {
        public int pkMenu { get; set; }
        public string fcDescripcion { get; set; }
        public string fcRuta { get; set; }
        public string fcIcono { get; set; }
        public int fiTipoMenu { get; set; }
        public int fiMenuPadre { get; set; }
        public int fiOrden { get; set; }
    }
}
