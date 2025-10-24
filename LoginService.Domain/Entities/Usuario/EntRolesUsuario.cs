using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Domain.Entities.Usuario
{
    public class EntRolesUsuario
    {
        public string fcLlaveMaestra { get; set; }
        public int fkIdRol { get; set; }
        [Key]
        public int fnNumeroEmpleado { get; set; }
    }
}
