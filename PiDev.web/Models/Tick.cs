using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System;
using PiDev.Domain.Entities;

namespace PiDev.web.Models
{
    public class Tick {

        public int id { get; set; }

        
        public bool assignement { get; set; }

       
        public DateTime? date { get; set; }

      
        public string description { get; set; }

        public int estimatedHours { get; set; }

        public int? status { get; set; }

       
        public string title { get; set; }

        public int? employee_id { get; set; }

        public virtual user user { get; set; }

    }
}
