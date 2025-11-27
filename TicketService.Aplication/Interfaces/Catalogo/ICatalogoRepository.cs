using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Domain.Entities;
using TicketService.Domain.Entities.Catalogo;

namespace TicketService.Aplication.Interfaces.Catalogo
{
    public interface ICatalogoRepository
    {
        Task<List<EntCatalogo>> obtenerAreaServicio();
        Task<List<EntCatalogo>> obtenerTipoSolicitud(int idArea);
        Task<List<EntCatalogo>> obtenerUnidadNegocio(int idArea, int idSolicitud);
        Task<List<EntCatalogo>> obtenerCatalogosVarios(int opc, int idParam, string nombreParam);
        Task<List<EntCatalogo>> obtenerReferente(int idArea, int idSolicitud, int idUnidadNegocio, int estatus);
        Task<List<EntCeco>> obtenerCeco();
        Task<List<EntAuditor>> obtenerAuditores(string busqueda);

    }
}
