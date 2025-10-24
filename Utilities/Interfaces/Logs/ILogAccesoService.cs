using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities.Logs;

namespace Utilities.Interfaces.Logs
{
    public interface ILogAccesoService
    {
        Task LogAccesoAsync(EntULogAcceso log);
    }
}
