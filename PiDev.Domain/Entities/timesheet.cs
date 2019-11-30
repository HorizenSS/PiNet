namespace PiDev.Domain.Entities

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.timesheet")]
    public partial class timesheet
    {
        public int id { get; set; }

        public TimeSpan? clock_in { get; set; }

        public TimeSpan? clock_out { get; set; }

        [Column(TypeName = "date")]
        public DateTime? day { get; set; }

        public int? owner_id { get; set; }

        public int? settings_id { get; set; }

        public virtual settings settings { get; set; }

        public virtual user user { get; set; }
    }
}
