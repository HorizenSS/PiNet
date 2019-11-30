namespace PiDev.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.reclamationfrais")]
    public partial class reclamationfrais
    {
        [Key]
        public int idRec { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string periority { get; set; }

        [StringLength(255)]
        public string type { get; set; }
    }
}
