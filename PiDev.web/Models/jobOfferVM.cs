using PiDev.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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




        public IEnumerable<SelectListItem> Skills { get; set; }
        public List<int> SelectedSkillIds { get; set; }


    }
}