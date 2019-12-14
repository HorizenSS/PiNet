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
    public class ContratService : Service<contrat> , IContratService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);
        public ContratService():base(utk)
        {

        }
    }
}
