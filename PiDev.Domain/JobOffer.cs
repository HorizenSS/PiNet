using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Domain
{
    [Table("jobOffer")]
    public class jobOffer
    {
        public jobOffer()
        {
           
        }
        [Key]
        public int IdJobOffer { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public int salary { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }

        [StringLength(255)]
        public string DocumentsUrl { get; set; }


        public ICollection<skill> Skills { get; set; }






    }
}
