namespace PiDev.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("ticketOcr")]
    public class TicketOcr
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Date { get; set; }
        [StringLength(255)]
        public string ArticlesDetails { get; set; }
        [StringLength(255)]
        public string Totale { get; set; }
    }
}
