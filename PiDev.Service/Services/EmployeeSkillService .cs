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

namespace PiDev.Service
{
    //fiha kol chay, toutes les méthodes spécifiques sauf CRUD

    //Service<Film> classe mère contenant les CRUD
    public class EmployeeSkillService : Service<EmployeeSkill>, IEmployeeSkillService
    {
        //Pour utiliser quelque chose de la couche Data, on a besoin de l'Unit of Work
        //L'unit of work nécessite le context(db factory) au niveau du constructeur
        //Le Factory est l'usine de fabrication d'objets
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public EmployeeSkillService() : base(utk)
        {

        }
        public IEnumerable<employe> employesSkillExperience(String a)
        {
            var EmployeeSkills = GetMany(d => d.skill.name == a && (DateTime.Now - d.DateAssigned).Days > 365);
            var employes = from d in EmployeeSkills
                           select d.employe;
            return employes;
        }
     


    }

    
}
