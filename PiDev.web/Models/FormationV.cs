using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PiDev.Domain.Entities;

namespace PiDev.web.Models
{
    public class FormationV
    {
        public int idFormation { get; set; }

      
        public DateTime? dateDebut { get; set; }

        public DateTime? dateFin { get; set; }

       
        public string domaineFormation { get; set; }

       
        public string titleFormation { get; set; }
        

       
        

        public virtual former former { get; set; }

        public virtual ICollection<avis> avis { get; set; }

        public virtual ICollection<test> test { get; set; }

    }
}