using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consomi.Data.Infrastructure
{
    public interface IDataBaseFactory:IDisposable
    {
        ConsomiContext Ctxt { get; }
    }
}
