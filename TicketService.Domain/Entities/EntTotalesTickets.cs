using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.Domain.Entities
{
    public class EntTotalesTickets
    {
        [Key]
        public int pkId { get; set; }
        public string fcDescripcion { get; set; }
        public int fnTotal { get; set; }

    }
}
