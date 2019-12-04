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
    public class userService : Service<user>, IUserService
    {
         static IDataBaseFactory Factory = new DataBaseFactory();
         static IUnitOfWork Uok = new UnitOfWork(Factory);
        IDataBaseFactory dbfactory = null;
        public userService() : base(Uok)
         {


          }

        public user FindRoleByName(string name)
        {
            IEnumerable<user> ls = this.GetMany().Where(p => p.email == name).Take(1);
            user c = new user();
            foreach (var i in ls)
            {
                
                c.password = i.password;
                c.role = i.role;
            }
            return c;
        }
    }
}
