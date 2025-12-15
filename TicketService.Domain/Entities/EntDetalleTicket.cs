using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.Domain.Entities
{
    public class EntDetalleTicket
    {
        [Key]
        public int? folio { get; set; }
        public int? id_area { get; set; }
        public string? area { get; set; } 
        public int? id_requerimiento { get; set; }
        public string? tipo_requerimiento { get; set; } 
        public string? prioridad { get; set; } 
        public int? folio_referente_a { get; set; }
        public string? Nombre_referente { get; set; } 
        public string? unidad_negocio { get; set; } 
        public int? id_estatus { get; set; }
        public string? estatus { get; set; } 
        public string? folio_honestel { get; set; } 

        public string? descripcion { get; set; } 
        public string? fecha_alta { get; set; }
        public string? fecha_asignacion { get; set; }
        public string? fecha_cierre { get; set; }
        public string? usuario_llave_maestra_creacion { get; set; } 
        public string? nombre_usuario_creacion { get; set; } 
        public string? celular_usuario_creacion { get; set; } 
        public string? usuario_llave_maestra_asignacion { get; set; } 
        public string? nombre_usuario_asignacion { get; set; } 
        public string? celular_usuario_asignacion { get; set; } 
        public string? extension_usuario_creacion { get; set; } 
        public string? extension_usuario_asignacion { get; set; } 
        public string? centro_de_costos_cobro { get; set; } 
        public int? horas_a_cobrar { get; set; }
        public int? minutos_a_cobrar { get; set; }
        public string? fecha_hora_alta { get; set; }
        public string? tipo_Problema_Solicitud { get; set; } 
        public string? EstadoAtencion { get; set; } 
        public bool? Escalado { get; set; }
        public string? tipo_incidente { get; set; } 
        public string? foliosAsociados { get; set; } 
        public string? folio_ada { get; set; } 
    }
}
