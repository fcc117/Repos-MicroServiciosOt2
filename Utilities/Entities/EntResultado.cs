using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities
{
    public class EntResultado
    {
        public bool exito { get; set; }
        public string error { get; set; }

        public string codeError { get; set; }
        public HttpStatusCode httpStatusCode { get; set; }
        public string sValor { get; set; }
    }

    public class EntResultado<T> : EntResultado
    {
        public T data { get; set; }
        public List<T> datalist { get; set; }
        public List<object> objectlist { get; set; }
        public object objects { get; set; }

        public int value { get; set; }
        public int rows { get; set; }
        public string accessToken { get; set; }
        public int expireIn { get; set; }
        public string refreshToken { get; set; }

    }
}
