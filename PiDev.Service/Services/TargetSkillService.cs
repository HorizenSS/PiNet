using Data.Infrastructures;
using PiDev.Domain;
using PiDev.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Service.Services
{
   public class TargetSkillService : Service<TargetSkill>
    {

        private static IDataBaseFactory dbf = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public TargetSkillService()
           : base(ut)
        {
            dbf = new DataBaseFactory();
            ut = new UnitOfWork(dbf);
        }

        public IEnumerable<TargetSkill> DisplayTargetSkillsByjobOffer(int idjobOffer)
        {
            return ut.GetRepositoryBase<TargetSkill>().GetMany(x => x.idJobOffer == idjobOffer);
        }


        public void DeleteTargetSkill(string description)
        {
            ut.GetRepositoryBase<TargetSkill>().DeletebyCondition(x => x.Description == description);
        }

        public TargetSkill FindTargetSkillByPk(string description)
        {
            return ut.GetRepositoryBase<TargetSkill>().GetMany(x => x.Description == description).First();
        }

        public string FindNamejobOfferById(int idjobOffer)
        {
            return ut.GetRepositoryBase<jobOffer>().GetById(idjobOffer).Name;
        }

        public int numberOfAccomplishTargetSkillsByjobOffer(int idjobOffer)
        {

            return ut.GetRepositoryBase<TargetSkill>().GetMany(x => x.idJobOffer == idjobOffer && x.state.ToString().Equals("1")).Count();
        }

        public int numberOfInProgressTargetSkillsByjobOffer(int idjobOffer)
        {

            return ut.GetRepositoryBase<TargetSkill>().GetMany(x => x.idJobOffer == idjobOffer && x.state.ToString().Equals("2")).Count();
        }

        public int numberOfNotStartedTargetSkillsByjobOffer(int idjobOffer)
        {

            return ut.GetRepositoryBase<TargetSkill>().GetMany(x => x.idJobOffer == idjobOffer && x.state.ToString().Equals("3")).Count();
        }

        public string jobOfferDeadlineVerification(int idjobOffer)
        {
            //DateTime startDate = (DateTime) ut.GetRepositoryBase<jobOffer>().GetById(idjobOffer).StartDate;
            DateTime endDate = (DateTime)ut.GetRepositoryBase<jobOffer>().GetById(idjobOffer).EndDate;
            DateTime Now = DateTime.Now;
            int result = DateTime.Compare(endDate, Now);
            TimeSpan t = endDate - Now;
            if (result > 0) { return "the DeadLine will be in" + t.Days + " days"; }
            else { return "the DeadLine Was passed"; }

        }

    }
}
