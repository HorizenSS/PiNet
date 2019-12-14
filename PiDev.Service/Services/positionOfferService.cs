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
    public class positionOfferService : Service<positionOffer>

    {
        private static IDataBaseFactory dbf = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public positionOfferService()
           : base(ut)
        {
            dbf = new DataBaseFactory();
            ut = new UnitOfWork(dbf);
        }


        public IEnumerable<positionOffer> ActivepositionOffer()
        {

            DateTime now = DateTime.Now;

            return ut.GetRepositoryBase<positionOffer>().GetMany(x => x.EndDate > now);

        }


        public IEnumerable<positionOffer> PassedpositionOffer()
        {

            DateTime now = DateTime.Now;

            return ut.GetRepositoryBase<positionOffer>().GetMany(x => x.EndDate < now);

        }


    }
}
