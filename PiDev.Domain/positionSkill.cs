

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Domain
{

    public class positionSkill
    {   [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public int idPositionOffer { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string state { get; set; }
        public Nullable<int> cin { get; set; }
        public virtual positionOffer positionOffer { get; set; }
      //   public virtual utilisateur user { get; set; }

       
    }

    public enum State
    {
        ToDo, Doing, Done
    }
  
}

