using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Domain.Entities
{
    [Table("pidevds.user")]
   public class user
    {
        [Key]
        public int id { get; set; }
        [StringLength(255)]
        public string email { get; set; }
        [StringLength(255)]
        public string password { get; set; }
        [StringLength(255)]
        public string role { get; set; }

    }
}
