namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PiDev.Domain;

    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("PidevContext")
        {
        }

        public virtual DbSet<TicketOcr> TicketOcr { get; set; }
        public virtual DbSet<skill> skill { get; set; }
        public virtual DbSet<jobOffer> jobOffer { get; set; }
        public virtual DbSet<qualification> qualification{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<skill>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.name)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<PiDev.Domain.employe> employes { get; set; }
    }
}
