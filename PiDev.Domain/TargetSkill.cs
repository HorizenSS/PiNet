using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Domain
{
   public class TargetSkill
    {
        [Key]
        public int targetId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int idJobOffer { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
      
        public State state { get; set; }
        public Nullable<int> cin { get; set; }
        public virtual jobOffer JobOffer { get; set; }
        public virtual employe Employe { get; set; }


           
   

    
}

   
};


