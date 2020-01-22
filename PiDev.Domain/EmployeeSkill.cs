using PiDev.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Domain
{
  public  class EmployeeSkill
    { 
        [Display(Name = "Date assigned")]
        public DateTime DateAssigned { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
       [Range(0, 5, ErrorMessage = "level Must be between 0 to 5")]
        public int level { get; set; }

        [Key, Column(Order=1)]
        [ForeignKey("employe")]

        public int employeFK { get; set; }
        public PiDev.Domain.employe employe { get; set; }
        [Key, Column(Order=2)]
        [ForeignKey("skill")]
        public int skillFK { get; set; }
        public skill skill { get; set; }
    }
}
