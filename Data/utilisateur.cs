namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.utilisateur")]
    public partial class utilisateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public utilisateur()
        {
            userfeedback = new HashSet<userfeedback>();
            userquiz = new HashSet<userquiz>();
            userquizresponse = new HashSet<userquizresponse>();
            userskill = new HashSet<userskill>();
        }

        [Required]
        [StringLength(31)]
        public string type { get; set; }

        public long id { get; set; }

        [Column(TypeName = "bit")]
        public bool Actif { get; set; }

        [StringLength(255)]
        public string adresse { get; set; }

        [StringLength(255)]
        public string cin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datNais { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [Column(TypeName = "bit")]
        public bool firstLogin { get; set; }

        [StringLength(16777215)]
        public string image { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [StringLength(255)]
        public string tel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userfeedback> userfeedback { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userquiz> userquiz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userquizresponse> userquizresponse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userskill> userskill { get; set; }
    }
}
