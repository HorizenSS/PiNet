using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiDev.web.Models
{
    public class SkillVM
    {   [Key]
        public int skillId { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        
    }
}