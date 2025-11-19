using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Domain.Entities.Catalogo;
using Utilities.Entities;

namespace TicketService.Aplication.UseCase.Catalogo
{
    public class ObtenerCatalogosVariosQuery : IRequest<EntResultado<EntCatalogo>>
    {
        public int opc { get; set; }
        public int idParam { get; set; }
        public string nombreParam { get; set; }

    }
}
