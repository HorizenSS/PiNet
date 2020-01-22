using Data.Infrastructures;
using Data;


using PiDev.Service.IServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiDev.ServicePattern;
using PiDev.Domain;
using PiDev.Service.Services;

namespace PiDev.Service
{
    //fiha kol chay, toutes les méthodes spécifiques sauf CRUD

    //Service<Film> classe mère contenant les CRUD
    public class EmployeService : Service<employe>, IEmployeService
    {
        //Pour utiliser quelque chose de la couche Data, on a besoin de l'Unit of Work
        //L'unit of work nécessite le context(db factory) au niveau du constructeur
        //Le Factory est l'usine de fabrication d'objets
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public EmployeService() : base(utk)
        {

        }

        public employe FindRoleByName(string name)
        {
            IEnumerable<employe> ls = this.GetMany().Where(p => p.email == name).Take(1);
            employe c = new employe();
            foreach (var i in ls)
            {

                c.password = i.password;
                c.role = i.role;
            }
            return c;
        }

    }
}
