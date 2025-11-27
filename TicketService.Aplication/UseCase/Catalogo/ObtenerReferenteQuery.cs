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
    public class ObtenerReferenteQuery : IRequest<EntResultado<EntCatalogo>>
    {
        public int idArea { get; set; }
        public int idSolicitud { get; set; }
        public int idUnidadNegocio { get; set; }
        public int estatus { get; set; }
    }
}
