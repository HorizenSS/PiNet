using Data.Infrastructures;
using PiDev.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

using PiDev.Domain;


namespace Service
{
    public class TicketOCRService : Service<TicketOcr>, ITicketOCRService
    {
      
        private static IDataBaseFactory dbf = new DataBaseFactory();
        private static IUnitOfWork unitOfWork = new UnitOfWork(dbf);
        public TicketOCRService() : base(unitOfWork)
        {

        }
    }
}
