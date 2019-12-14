using ADVYTEAM.Data;
using ADVYTEAM.Data.Infrastructure;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVYTEAM.Services
{
    public class MessageService : Service<message> , IMessageService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);
        public MessageService():base(utk)
        {

        }

        public IEnumerable<message> GetMessagesBySenderReciver(long idr, long ids)
        {
            return  GetMany(
                                    message => (message.id_receiver == ids &&
                                               message.id_sender == idr) ||
                                               (message.id_receiver == idr &&
                                               message.id_sender == ids)
                                    );
        }
    }
}
