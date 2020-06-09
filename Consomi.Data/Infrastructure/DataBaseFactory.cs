using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consomi.Data.Infrastructure
{
    public class DataBaseFactory: Disposable, IDataBaseFactory
    {
        ConsomiContext ctxt;
    
        public DataBaseFactory()
        {
            ctxt = new ConsomiContext();
        }

        public DataBaseFactory(ConsomiContext context)
        {
            this.ctxt = context;
        }

        public ConsomiContext Ctxt { get { return ctxt; } }
        public override void DisposeCore()
        {
            if (ctxt != null)
                ctxt.Dispose();
        }
    }
}
