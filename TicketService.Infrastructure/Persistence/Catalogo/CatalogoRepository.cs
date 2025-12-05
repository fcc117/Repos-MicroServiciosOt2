using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Aplication.Interfaces.Catalogo;
using TicketService.Domain.Entities.Catalogo;

namespace TicketService.Infrastructure.Persistence.Catalogo
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly CatalogoDbContext _dbContext;
        public CatalogoRepository(CatalogoDbContext context)
        {
            _dbContext = context;
        }
        public async Task<List<EntCatalogo>> obtenerAreaServicio()
        {
            return await Task.Run(() => _dbContext.obtenerAreaServicio());
        }
        public async Task<List<EntCatalogo>> obtenerTipoSolicitud(int idArea)
        {
            return await Task.Run(() => _dbContext.obtenerTipoSolicitud(idArea));
        }
        public async Task<List<EntCatalogo>> obtenerUnidadNegocio(int idArea, int idSolicitud)
        {
            return await Task.Run(() => _dbContext.obtenerUnidadNegocio(idArea, idSolicitud));
        }
        public async Task<List<EntCatalogo>> obtenerCatalogosVarios(int opc, int idParam, string nombreParam)
        {
            return await Task.Run(() => _dbContext.obtenerCatalogosVarios(opc, idParam, nombreParam));
        }
        public async Task<List<EntCatalogo>> obtenerReferente(int idArea, int idSolicitud, int idUnidadNegocio, int estatus)
        {
            return await Task.Run(() => _dbContext.obtenerReferente(idArea, idSolicitud, idUnidadNegocio, estatus));
        }
        public async Task<List<EntCeco>> obtenerCeco()
        {
            return await Task.Run(() => _dbContext.obtenerCeco());
        }
        public async Task<List<EntAuditor>> obtenerAuditores(string busqueda)
        {
            return await Task.Run(() => _dbContext.obtenerAuditores(busqueda));
        }
        public async Task<List<EntCatalogo>> obtenerVerTickets(string fcNumeroEmpleado)
        {
            return await Task.Run(() => _dbContext.obtenerVerTickets(fcNumeroEmpleado));
        }
        public async Task<List<EntCatalogo>> obtenerEstatus()
        {
            return await Task.Run(() => _dbContext.obtenerEstatus());
        }
        public async Task<List<EntCatalogo>> obtenerAntiguedad()
        {
            return await Task.Run(() => _dbContext.obtenerAntiguedad());
        }

    }
}
