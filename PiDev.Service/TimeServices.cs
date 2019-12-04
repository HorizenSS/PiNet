using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiDev.ServicePattern;
using PiDev.Domain.Entities;
using Data.Infrastructure;
using System.Linq.Expressions;

namespace PiDev.Service
{
    public class TimeServices : Service<timesheet>, ITimeService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbfactor);
        IDatabaseFactory dbfactory = null;

        public TimeServices() : base(utwk)
        {

        }

        public void addLog(timesheet t,user u)
        {
           
            t.owner_id = u.id;
            t.clock_in = DateTime.Now;
            t.clock_out = DateTime.Now;
            utwk.getRepository<timesheet>().Add(t);

        }
    }
}
