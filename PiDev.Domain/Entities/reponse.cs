namespace PiDev.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.reponse")]
    public partial class reponse
    {
        [Key]
        public int idRep { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Column(TypeName = "bit")]
        public bool? isValide { get; set; }

        public int? quest_idQues { get; set; }

        public virtual question question { get; set; }
    }
}
