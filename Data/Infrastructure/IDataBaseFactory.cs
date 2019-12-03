using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Data.Infrastructure
{
    public interface IDataBaseFactory:IDisposable
    {
        MyDBContext Ctxt { get; }
    }
}
