using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Domain.Entities.Usuario
{
    public class EntUsuarioSaml
    {
        public string NumeroEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Empresa { get; set; }
        public string CentroCostos { get; set; }
        public string Correo { get; set; }
        public string Puesto { get; set; }
    }
}
