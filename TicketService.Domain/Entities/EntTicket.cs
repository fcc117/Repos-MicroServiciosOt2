using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.Domain.Entities
{
    public class EntTicket
    {
        [Key]
        public int folio { get; set; }
        public int id_area { get; set; }
        public int id_tipo_requerimiento { get; set; }
        public int id_unidad_negocio { get; set; }
        public int folio_honestel { get; set; }
        public string? descripcion { get; set; }
        public string? usuario_llave_maestra_creacion { get; set; }
        public string? centro_de_costos_cobro { get; set; }
        public int folio_comercio { get; set; }
        public string? tipo_PSolicitud { get; set; }
        public string? tipo_incidente { get; set; }
        public int id_referente_a { get; set; }
        public string? listaConsultores { get; set; }
        public List<EntArchivo>? listaDocumentos { get; set; }

    }
    public class EntArchivo
    {
        [Key]
        public int folio { get; set; }
        public string? nombre { get; set; }
        public string? archivo { get; set; }
        public int tamaño { get; set; }
        public string? extension { get; set; }
        public string? usuario_llave_maestra { get; set; }

    }
}
