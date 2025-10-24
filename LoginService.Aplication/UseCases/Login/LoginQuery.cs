using LoginService.Domain.Entities.Usuario;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace LoginService.Aplication.UseCases.Login
{
    public class LoginQuery:IRequest<EntResultado<EntUsuario>>
    {
        public string fcNumeroEmpleado { get; set; }
        public string fcUserAgent { get; set; }
        public string fcPassword { get; set; }

    }
}
