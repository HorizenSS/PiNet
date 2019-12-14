using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructures
{
    public interface IDataBaseFactory :IDisposable
    {
       PidevContext DataContext { get;  }
    }
}
