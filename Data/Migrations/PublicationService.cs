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
    public class PublicationService  : Service<publication> , IPublicationService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);

        public PublicationService() : base(utk)
        {

        }
    }
}
