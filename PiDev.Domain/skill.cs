namespace PiDev.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.skill")]
    public partial class skill
    {   [Key]
        public int skillId { get; set; }

        [StringLength(255)]
        public string category { get; set; }

        [StringLength(255)]
        public string name { get; set; }
    }
}
