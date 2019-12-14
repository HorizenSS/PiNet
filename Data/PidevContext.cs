namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
   

    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("name=PidevContext")
        {
        }
        public virtual DbSet<PiDev.Domain.positionSkill> positionSkills { get; set; }
        public virtual DbSet<resume> resume { get; set; }
        public virtual DbSet<skill> skill { get; set; }
        public virtual DbSet<PiDev.Domain.positionOffer> positionOffers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<resume>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<resume>()
                .Property(e => e.note)
                .IsUnicode(false);

          /*  modelBuilder.Entity<skill>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.name)
                .IsUnicode(false);*/
        }

       
    }
}
