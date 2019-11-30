namespace PiDev.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.employe")]
    public partial class employe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employe()
        {
            avis = new HashSet<avis>();
            workedon = new HashSet<workedon>();
        }

        [Key]
        public int cin { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime? birthDate { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<avis> avis { get; set; }

        public virtual devteam devteam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<workedon> workedon { get; set; }
    }
}
