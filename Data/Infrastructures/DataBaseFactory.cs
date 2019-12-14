using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructures
{
    public class DataBaseFactory : Disposable,IDataBaseFactory
    {

        private PidevContext datacontext;

        public PidevContext DataContext
        {
            get { return datacontext; }
            
        }

        public DataBaseFactory()
        {
            datacontext = new PidevContext();
        }

        public override void DisposeCore()
        {
            if (datacontext != null)
                datacontext.Dispose();
        }
    }
}
