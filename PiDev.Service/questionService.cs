using Data.Infrastructure;
using PiDev.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PiDev.Service
{
    public class questionService : Service<question>,IQuestion
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);

        public questionService(IUnitOfWork Uok) : base(Uok)
        {
           

        }
        public List<reponse> reponseD(int id)
        {
            List<reponse> appo = new List<reponse>();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<reponse> jbService = new Service<reponse>(Uok);
            List<reponse> j = new List<reponse>();
            

            appo = jbService.GetAll().ToList();
            for (int i = appo.Count - 1; i >= 0; i--)
            {
                if (appo[i].quest_idQues == id)
                {
                    //j.Add(appo[i]);
                    j.Remove(appo[i]);
                  
                }

            }
            return appo;
        }
    }
}
