using ADVYTEAM.Data;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVYTEAM.Services
{
    public interface IMessageService : IService<message>
    {
        IEnumerable<message> GetMessagesBySenderReciver(long idr, long ids);
    }
}
