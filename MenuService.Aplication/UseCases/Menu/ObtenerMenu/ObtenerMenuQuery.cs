using MediatR;
using MenuService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace MenuService.Aplication.UseCases.Menu.ObtenerMenu
{
    public class ObtenerMenuQuery : IRequest<EntResultado<EntMenu>>
    {
        public string fcNumeroEmpleado { get; set; }
    }
}
