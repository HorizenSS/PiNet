namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PiDev.Domain;
    using Data.Configurations;

    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("PidevContext")
        {
         
        }
     
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<TicketOcr> TicketOcr { get; set; }
        public virtual DbSet<skill> skill { get; set; }
        public virtual DbSet<jobOffer> jobOffer { get; set; }
        public virtual DbSet<qualification> qualification{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new skillConfig());
            modelBuilder.Entity<skill>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<jobOffer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<jobOffer>()
                .Property(e => e.Description)
                .IsUnicode(false);
            modelBuilder.Entity<EmployeeSkill>()
               .Property(e => e.Description)
               .IsUnicode(false);

            modelBuilder.Entity<jobOffer>()
         .HasMany(r => r.Skills)
         .WithMany();


        }
        public virtual DbSet<jobofferskills> jobofferskills { get; set; }
        public System.Data.Entity.DbSet<PiDev.Domain.employe> employes { get; set; }
        public virtual DbSet<TargetSkill> TargetSkills { get; set; }
        
    }
}
