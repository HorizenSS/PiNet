using Data;
using Data.Infrastructures;


using PiDev.Service.IServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiDev.ServicePattern;

using PiDev.Domain;

namespace PiDev.Service
{
    public class jobOfferService : Service<jobOffer>

    {
        private static IDataBaseFactory dbf = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public jobOfferService()
           : base(ut)
        {
            dbf = new DataBaseFactory();
            ut = new UnitOfWork(dbf);
        }


        public IEnumerable<jobOffer> ActivejobOffer()
        {

            DateTime now = DateTime.Now;

            return ut.GetRepositoryBase<jobOffer>().GetMany(x => x.EndDate > now);

        }


        public IEnumerable<jobOffer> PassedjobOffer()
        {

            DateTime now = DateTime.Now;

            return ut.GetRepositoryBase<jobOffer>().GetMany(x => x.EndDate < now);

        }

    }
}
