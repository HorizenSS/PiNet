using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Data.Infrastructure
{
    public class DataBaseFactory: Disposable, IDataBaseFactory
    {
        MyDBContext ctxt;

        public MyDBContext Ctxt
        {
            get
            {
                return ctxt;
            }
        }

        public DataBaseFactory()
        {
            ctxt = new MyDBContext();
        }

        public override void DisposeCore()
        {
            if (ctxt != null)
                ctxt.Dispose();
        }
    }
}
