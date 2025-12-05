using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.Domain.Entities
{
    public class EntTickets
    {
        [Key]
        public int? folio { get; set; }
        public DateTime? fecha_alta { get; set; }
        public DateTime? fecha_asignacion { get; set; }
        public DateTime? fecha_cierre { get; set; }
        public string? usuario_creacion { get; set; } 
        public string? areas { get; set; }
        public string? tipo_requerimiento { get; set; }
        public string? unidad_negocio { get; set; }
        public string? referente_a { get; set; } 
        public string? estatus { get; set; } 
        public int? id_estatus { get; set; }
        public string? centro_de_costos_cobro { get; set; }
        public int? horas_a_cobrar { get; set; }
        public int? minutos_a_cobrar { get; set; }
        public string? usuario_que_atendio { get; set; }
    }
    public class EntTicketParam
    {
        public string UsuarioLlaveMaestra { get; set; } = string.Empty;
        public int FolioTicket { get; set; } = -1;
        public string AuditorSolicitante { get; set; } = string.Empty;
        public string AntiguedadRango { get; set; } = string.Empty;
        public int Antiguedad { get; set; } = -1;

        public DateTime? FechaRegistroDesde { get; set; }
        public DateTime? FechaRegistroHasta { get; set; }

        public int IdEstatus { get; set; } = -1;

        public DateTime? FechaCierreDesde { get; set; }
        public DateTime? FechaCierreHasta { get; set; }

        public int IdVerRegistros { get; set; } = -1;
        public int IdArea { get; set; } = -1;
    }
}
