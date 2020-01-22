namespace PiDev.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employe")]
    public partial class employe
    {

        public employe()
        {
           
            this.EmployeeSkills = new List<EmployeeSkill>();
        }


  
        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [Key]
        public int cin { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime? birthDate { get; set; }
        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string firstName { get; set; }

        public DateTime? hiringDate { get; set; }

        [StringLength(255)]
        public string lastName { get; set; }

        public int phoneNb { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        public float salary { get; set; }

        public int? devTeam_idTeam { get; set; }

        public int? resumeId { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
      
    }
}
