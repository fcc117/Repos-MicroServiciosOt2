using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Domain.Entities.Usuario
{
    public class EntRoles
    {
        [Key]
        public int pkId { get; set; }
        public string fcDescripcion { get; set; }
        public string fcEstatus { get; set; }
    }
}
