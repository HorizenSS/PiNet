using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PiDev.Data
{
    public class Model1 : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Model1() : base("name=Model1")
        {
        }

        public System.Data.Entity.DbSet<PiDev.Domain.Entities.ticket> tickets { get; set; }

        public System.Data.Entity.DbSet<PiDev.web.Models.Tick> Ticks { get; set; }

        public System.Data.Entity.DbSet<PiDev.Domain.Entities.task> tasks { get; set; }

        public System.Data.Entity.DbSet<PiDev.Domain.Entities.settings> settings { get; set; }

        public System.Data.Entity.DbSet<PiDev.Domain.Entities.test> tests { get; set; }

        public System.Data.Entity.DbSet<PiDev.Domain.Entities.employe> employes { get; set; }

        public System.Data.Entity.DbSet<PiDev.Domain.Entities.formation> formations { get; set; }
    }
}
