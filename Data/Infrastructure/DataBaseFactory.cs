using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class DataBaseFactory: Disposable, IDataBaseFactory
    {
        Context ctxt;

        public Context Ctxt
        {
            get
            {
                return ctxt;
            }
        }

        public DataBaseFactory()
        {
            ctxt = new Context();
        }

        public override void DisposeCore()
        {
            if (ctxt != null)
                ctxt.Dispose();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
