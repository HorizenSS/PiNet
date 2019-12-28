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
            this.Qualifications = new List<qualification>();
        }
        [Key]
        public int IdJobOffer { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Name { get; set; }
        public int salary { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
     

        public string DocumentsUrl { get; set; }
       
        public Nullable<int> cin { get; set; }
       
       
        public virtual ICollection<qualification> Qualifications { get; set; }
        public virtual employe employe { get; set; }
   




    }
}
