using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities.Token
{
    public class EntRefreshToken
    {
        public string Token { get; set; }
        public DateTime Expiry {  get; set; }
        public int UserId { get; set; }
    }
}
