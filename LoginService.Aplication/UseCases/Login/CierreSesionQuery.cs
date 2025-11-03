using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace LoginService.Aplication.UseCases.Login
{
    public class CierreSesionQuery:IRequest<EntResultado<int>>
    {
        public string fcNumeroEmpleado { get; set; }
        public string fcTipoAcceso { get; set; }
        public int fnTipoCierre { get; set; }
    }
}
