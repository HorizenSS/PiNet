using ADVYTEAM.Data;
using ADVYTEAM.Data.Infrastructure;
using ADVYTEAM.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVYTEAM.Services
{
    public class ReclamationService : Service<reclamation>, IReclamationService
    {
      
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);

        public ReclamationService() : base(utk)
        {
            //GetMany(reclamation=>reclamation.UserId== userc.id);
        }

        public IEnumerable<reclamation> GetMesReclmations(long id)
        {
            return GetMany(reclamation => reclamation.UserId == id);
        }

        public IEnumerable<reclamation> GetReclmationsAttent()
        {
            return GetMany(reclamation => reclamation.Etat== 0);
        }

        public IEnumerable<reclamation> GetReclmationsEnCour()
        {
            return GetMany(reclamation => reclamation.Etat == 1);
        }

        public IEnumerable<reclamation> GetReclmationsTraite()
        {
            return GetMany(reclamation => reclamation.Etat == 2);
        }
    }
}
