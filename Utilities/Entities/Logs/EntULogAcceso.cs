using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities.Logs
{
    public class EntULogAcceso
    {
        public string fcLlaveMaestra { get; set; }
        public int fnTipoSession { get; set; }
        public string fcIpMachine { get; set; }
        public string fcTicketSession { get; set; }
        public int fnOpcion { get; set; }
    }
}
