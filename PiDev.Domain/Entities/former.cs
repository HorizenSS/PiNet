namespace PiDev.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.former")]
    public partial class former
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public former()
        {
            formation = new HashSet<formation>();
        }

        [Key]
        public int idFormer { get; set; }

        [StringLength(255)]
        public string lastNameFormer { get; set; }

        [StringLength(255)]
        public string nameFormer { get; set; }

        [StringLength(255)]
        public string specialty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<formation> formation { get; set; }
    }
}
