using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.Domain.Entities.Catalogo
{
    public class EntAuditor
    {
        [Key]
        public string usuario_llave_maestra { get; set; }
        public string nombre { get; set; }
    }
}
