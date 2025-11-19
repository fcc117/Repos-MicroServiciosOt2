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
        public async Task<List<EntCatalogo>> obtenerUnidadNegocio(int idArea, int idRequerimiento)
        {
            return await Task.Run(() => _dbContext.obtenerUnidadNegocio(idArea, idRequerimiento));
        }
        public async Task<List<EntCatalogo>> obtenerCatalogosVarios(int opc, int idParam, string nombreParam)
        {
            return await Task.Run(() => _dbContext.obtenerCatalogosVarios(opc, idParam, nombreParam));
        }
    }
}
