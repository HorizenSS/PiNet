namespace PiDev.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.demande")]
    public partial class demande
    {
        [Key]
        public int idDe { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public float expenses { get; set; }

        [StringLength(255)]
        public string missionAdress { get; set; }

        public float otherExpenses { get; set; }

        public DateTime? reservationDate { get; set; }

        [StringLength(255)]
        public string statusF { get; set; }

        [StringLength(255)]
        public string ticketImg { get; set; }
    }
}
