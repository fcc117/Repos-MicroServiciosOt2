using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Domain.Entities.Usuario
{
    public class EntLogAcceso
    {
        public int pkId { get; set; }
        public string fcNumeroEmpleado { get; set; }
        public string fcTipoAcceso { get; set; }
        public string fcOrigenIP { get; set; }
        public string fcPCName { get; set; }
        public string fcUserDomainName { get; set; }
        public string fcNavegador { get; set; }
        public DateTime fdFechaUltimaSesion { get; set; }
        public bool fbEstatus { get; set; }
        public DateTime fdFechaRegistro { get; set; }
        public int fnTipoCierre { get; set; }
    }
}
