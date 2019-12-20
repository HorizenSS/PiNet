namespace PiDev.Domain
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

        public virtual DbSet<skill> skill { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<skill>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
