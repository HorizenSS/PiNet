using PiDev.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiDev.web.Models
{
    public class jobOfferVM
    {
        [Key]
        public int IdJobOffer { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Name { get; set; }
        public int salary { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }


        public string DocumentsUrl { get; set; }

        public Nullable<int> cin { get; set; }


        public virtual ICollection<qualification> Qualifications { get; set; }
        public virtual employe employe { get; set; }

    }
}