
using PiDev.Service.IServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiDev.ServicePattern;
using Data.Infrastructures;
using Data;

using PiDev.Domain;
using qualification = PiDev.Domain.qualification;
using jobOffer = PiDev.Domain.jobOffer;

namespace PiDev.Service
{
    public class qualificationService : Service<qualification>
    {
        private static IDataBaseFactory dbf = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public qualificationService()
           : base(ut)
        {
            dbf = new DataBaseFactory();
            ut = new UnitOfWork(dbf);
        }

        public IEnumerable<qualification> DisplayqualificationsByjobOffer(int idjobOffer)
        {
            return ut.GetRepositoryBase<qualification>().GetMany(x => x.idJobOffer == idjobOffer);
        }

       
        public void Deletequalification(string description)
        {
            ut.GetRepositoryBase<qualification>().DeletebyCondition(x => x.Description == description);
        }

        public qualification FindqualificationByPk(string description)
        {
            return ut.GetRepositoryBase<qualification>().GetMany(x => x.Description == description).First();
        }
                    
        public string FindNamejobOfferById(int idjobOffer)
        {
            return ut.GetRepositoryBase<jobOffer>().GetById(idjobOffer).Name;
        }

        public int numberOfAccomplishqualificationsByjobOffer(int idjobOffer) {

            return ut.GetRepositoryBase<qualification>().GetMany(x => x.idJobOffer == idjobOffer && x.state == "Done").Count();
        }

        public int numberOfInProgressqualificationsByjobOffer(int idjobOffer)
        {

            return ut.GetRepositoryBase<qualification>().GetMany(x => x.idJobOffer == idjobOffer && x.state =="Doing").Count();
        }

        public int numberOfNotStartedqualificationsByjobOffer(int idjobOffer)
        {

            return ut.GetRepositoryBase<qualification>().GetMany(x => x.idJobOffer == idjobOffer && x.state == "ToDo").Count();
        }

        public string jobOfferDeadlineVerification (int idjobOffer)
        {
            //DateTime startDate = (DateTime) ut.GetRepositoryBase<jobOffer>().GetById(idjobOffer).StartDate;
            DateTime endDate = (DateTime) ut.GetRepositoryBase<jobOffer>().GetById(idjobOffer).EndDate;
            DateTime Now = DateTime.Now;
            int result = DateTime.Compare(endDate,Now);
            TimeSpan t = endDate - Now;
            if (result > 0) { return "the DeadLine will be in"+ t.TotalDays+" days"; }
            else { return "the DeadLine Was passed"; }

        }


    }
}
