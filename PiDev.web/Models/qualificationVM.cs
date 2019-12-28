using PiDev.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiDev.web.Models
{
    public class qualificationVM
    {
       
     
        public string Description { get; set; }
        public int idJobOffer { get; set; }
        [NotMapped]
        public string jobname { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string state { get; set; }
        public Nullable<int> cin { get; set; }
        public string username { get; set; }
    }
    

}
