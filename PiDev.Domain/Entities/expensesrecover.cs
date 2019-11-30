namespace PiDev.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.expensesrecover")]
    public partial class expensesrecover
    {
        [Key]
        public int idEx { get; set; }

        public float amountCeiling { get; set; }

        [StringLength(255)]
        public string approve { get; set; }

        [StringLength(255)]
        public string feedBacks { get; set; }

        public DateTime? meetingDate { get; set; }

        public float recoveredExpenses { get; set; }
    }
}
