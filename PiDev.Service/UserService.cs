using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiDev.ServicePattern;
using PiDev.Domain.Entities;
using Data.Infrastructure;

namespace PiDev.Service
{
    public class UserService : Service<user>, IUserService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbfactor);
        IDatabaseFactory dbfactory = null;
        public UserService() : base(wow)
        {

        }
        public user FindRoleByName(string name)
        {
            IEnumerable<user> ls = this.GetMany().Where(p => p.login == name).Take(1);
            user c = new user();
            foreach (var i in ls)
            {
                c.login = i.login;
                c.password = i.password;
                c.role = i.role;
            }
            return c;
        }

      
    }
}
