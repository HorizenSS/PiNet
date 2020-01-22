
using PiDev.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Models
{
    public class EmployeeSkillVM
    {
        [Key, Column(Order = 0)]
        public DateTime DateAssigned { get; set; }
        [Range(0, 5)]
        public int level { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("skill")]
        [Display(Name= "skill")]
        public int skillFK { get; set; }
        public skill skill { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("employe")]
        [Display(Name = "employe")]

        public int employeFK { get; set; }
        public employe employe { get; set; }

        public IEnumerable<SelectListItem> skills { get; set; }
        public IEnumerable<SelectListItem> employes { get; set; }

    }
}