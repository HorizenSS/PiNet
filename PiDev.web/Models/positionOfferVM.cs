using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.web.Models
{

  public class positionOfferVM
    {
   
        [Key]
        public int IdPositionOffer { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string Type { get; set; }

        public string DocumentsUrl { get; set; }
        //public Nullable<int> cin { get; set; }
     
    
       
      
        public virtual ICollection<positionSkillVM> positionSkills { get; set; }
      //  public virtual employe employe { get; set; }
    


    }
}
