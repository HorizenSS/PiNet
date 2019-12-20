namespace PiDev.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mycompetence.skill")]
    public partial class skill
    {
        public int skillId { get; set; }

        [StringLength(255)]
        public string category { get; set; }

        [StringLength(255)]
        public string name { get; set; }
    }
}
