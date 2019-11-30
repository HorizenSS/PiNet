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
            workedon = new HashSet<workedon>();
            test = new HashSet<test>();
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

        public virtual devteam devteam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<workedon> workedon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test> test { get; set; }
    }
}
