
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
using positionSkill = PiDev.Domain.positionSkill;
using positionOffer = PiDev.Domain.positionOffer;

namespace PiDev.Service
{
    public class positionSkillService : Service<positionSkill>
    {
        private static IDataBaseFactory dbf = new DataBaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public positionSkillService()
           : base(ut)
        {
            dbf = new DataBaseFactory();
            ut = new UnitOfWork(dbf);
        }

        public IEnumerable<positionSkill> DisplaypositionSkillsBypositionOffer(int idPositionOffer)
        {
            return ut.GetRepositoryBase<positionSkill>().GetMany(x => x.idPositionOffer == idPositionOffer);
        }

       
        public void DeletepositionSkill(string description)
        {
            ut.GetRepositoryBase<positionSkill>().DeletebyCondition(x => x.Description == description);
        }

        public positionSkill FindpositionSkillByPk(string description)
        {
            return ut.GetRepositoryBase<positionSkill>().GetMany(x => x.Description == description).First();
        }
                    
        public string FindNamepositionOfferById(int idPositionOffer)
        {
            return ut.GetRepositoryBase<positionOffer>().GetById(idPositionOffer).Name;
        }

        public int numberOfAccomplishpositionSkillsBypositionOffer(int idPositionOffer) {

            return ut.GetRepositoryBase<positionSkill>().GetMany(x => x.idPositionOffer == idPositionOffer && x.state == "Done").Count();
        }

        public int numberOfInProgresspositionSkillsBypositionOffer(int idPositionOffer)
        {

            return ut.GetRepositoryBase<positionSkill>().GetMany(x => x.idPositionOffer == idPositionOffer && x.state =="Doing").Count();
        }

        public int numberOfNotStartedpositionSkillsBypositionOffer(int idPositionOffer)
        {

            return ut.GetRepositoryBase<positionSkill>().GetMany(x => x.idPositionOffer == idPositionOffer && x.state == "ToDo").Count();
        }

        public string positionOfferDeadlineVerification (int idPositionOffer)
        {
            //DateTime startDate = (DateTime) ut.GetRepositoryBase<positionOffer>().GetById(idPositionOffer).StartDate;
            DateTime endDate = (DateTime) ut.GetRepositoryBase<positionOffer>().GetById(idPositionOffer).EndDate;
            DateTime Now = DateTime.Now;
            int result = DateTime.Compare(endDate,Now);
            TimeSpan t = endDate - Now;
            if (result > 0) { return "the DeadLine will be in"+ t.TotalDays+" days"; }
            else { return "the DeadLine Was passed"; }

        }


    }
}
