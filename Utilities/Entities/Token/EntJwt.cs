using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities.Token
{
    public class EntJwt
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpiresMinutes {  get; set; }
        public int RefreshTokenExpiresDays { get; set; }
    }
}
