namespace PiDev.Domain.Entities

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.settings")]
    public partial class settings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public settings()
        {
            timesheet = new HashSet<timesheet>();
        }

        public int id { get; set; }
       
        public int breakTime_hours { get; set; }

        public int breakTime_minutes { get; set; }

        public int dailyLimit_hours { get; set; }

        public int dailyLimit_minutes { get; set; }
        [Required(ErrorMessage = "Field should not be empty")]
        public double doubleOvertimeRate { get; set; }

        public double overtimeRate { get; set; }

        public double regularRate { get; set; }

        public int weeklyLimit_hours { get; set; }

        public int weeklyLimit_minutes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timesheet> timesheet { get; set; }
    }
}
