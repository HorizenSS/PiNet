namespace PiDev.Domain.Entities

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidevds.ticket")]
    public partial class ticket
    {
        public int id { get; set; }

        [Column(TypeName = "bit")]
        public bool assignement { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

       
        public string description { get; set; }

       public int estimatedHours { get; set; }

        public string status { get; set; }

     
        public string title { get; set; }
       
        public int? employee_id { get; set; }

        public virtual user user { get; set; }
    }
}
