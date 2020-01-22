namespace PiDev.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
   
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skill")]
    public class skill
    {
        private int v1;
        private string v2;
        private string v3;

        public skill()
        {
                    
        }

        public skill(int v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        [Key]
        public int skillId { get; set; }

        [StringLength(255)]
        public string name { get; set; }
        [StringLength(255)]
        public string category { get; set; }


        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
       


    }
}
