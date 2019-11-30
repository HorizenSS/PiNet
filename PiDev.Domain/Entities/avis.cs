namespace PiDev.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.avis")]
    public partial class avis
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEmp { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idFor { get; set; }

        [StringLength(255)]
        public string commentaire { get; set; }

        public int? cin { get; set; }

        public int? idFormation { get; set; }

        public virtual employe employe { get; set; }

        public virtual formation formation { get; set; }
    }
}
