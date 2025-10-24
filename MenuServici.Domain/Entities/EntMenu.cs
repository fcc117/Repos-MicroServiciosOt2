using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuService.Domain.Entities
{
    public class EntMenu
    {
        [Key]
        public int pkMenu { get; set; }
        public string fcDescripcion { get; set; }
        public string fcRuta { get; set; }
        public string fcIcono { get; set; }
        public int fiTipoMenu { get; set; }
        public int fiMenuPadre { get; set; }
        public int fiOrden { get; set; }
    }
}