namespace PiDev.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.workedon")]
    public partial class workedon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idEmp { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTask { get; set; }

        public DateTime? beginingOn { get; set; }

        public DateTime? endingOn { get; set; }

        public int? cin { get; set; }

        public virtual employe employe { get; set; }

        public virtual task task { get; set; }
    }
}
