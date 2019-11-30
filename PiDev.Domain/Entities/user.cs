namespace PiDev.Domain.Entities

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            ticket = new HashSet<ticket>();
            timesheet = new HashSet<timesheet>();
            user1 = new HashSet<user>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Firstname { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string cin { get; set; }

        [StringLength(255)]
        public string grade { get; set; }

        [StringLength(255)]
        public string login { get; set; }

        [StringLength(255)]
        public string mail { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public int rating { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        public double? salary { get; set; }

        [StringLength(255)]
        public string speciality { get; set; }

        public int? manager_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket> ticket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timesheet> timesheet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> user1 { get; set; }

        public virtual user user2 { get; set; }
    }
}
