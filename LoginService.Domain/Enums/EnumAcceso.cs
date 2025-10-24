using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Domain.Enums
{
    public class EunumAcceso
    {
        public enum TiposAccessLogin : int
        {
            LOGIN = 1,
            LOGOUT = 2,
            USER_INVALID = 3,
            PASSWORD_INCORRECT = 4,
            ERROR_ACCESS = 5
        }
    }
}
