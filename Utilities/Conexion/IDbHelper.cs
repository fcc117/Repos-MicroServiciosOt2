using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Conexion
{
    public interface IDbHelper
    {
        Task<int> ExecuteNonQueryAsync(string procedureName, Dictionary<string, object> parameters);
        Task<object> ExecuteScalarAsync(string procedureName, Dictionary<string, object> parameters);
        Task<DataTable> ExecuteDataTableAsync(string procedureName, Dictionary<string, object> parameters);
    }
}
