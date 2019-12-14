

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Domain
{

  public class positionOffer
    {
   
        [Key]
        public int IdPositionOffer { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string Type { get; set; }
    //    public virtual utilisateur Employe { get; set; }
        public string DocumentsUrl { get; set; }
        public Nullable<int> id_user { get; set; }
     
    
       
      
        public virtual ICollection<positionSkill> positionSkills { get; set; }
      //  public virtual employe employe { get; set; }
    


    }
}
