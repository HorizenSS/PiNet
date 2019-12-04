namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PiDev.Domain.Entities;

    public partial class Context : DbContext
    {
        public Context()
            
        {
        }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<avis> avis { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<demande> demande { get; set; }
        public virtual DbSet<devteam> devteam { get; set; }
        public virtual DbSet<employe> employe { get; set; }
        public virtual DbSet<expensesrecover> expensesrecover { get; set; }
        public virtual DbSet<formation> formation { get; set; }
        public virtual DbSet<former> former { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<question> question { get; set; }
        public virtual DbSet<reclamationfrais> reclamationfrais { get; set; }
        public virtual DbSet<reponse> reponse { get; set; }
        public virtual DbSet<task> task { get; set; }
        public virtual DbSet<test> test { get; set; }
        public virtual DbSet<workedon> workedon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<avis>()
                .Property(e => e.commentaire)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.missionAdress)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.statusF)
                .IsUnicode(false);

            modelBuilder.Entity<demande>()
                .Property(e => e.ticketImg)
                .IsUnicode(false);

            modelBuilder.Entity<devteam>()
                .Property(e => e.Tech)
                .IsUnicode(false);

            modelBuilder.Entity<devteam>()
                .Property(e => e.technologie)
                .IsUnicode(false);

            modelBuilder.Entity<devteam>()
                .HasMany(e => e.employe)
                .WithOptional(e => e.devteam)
                .HasForeignKey(e => e.devTeam_idTeam);

            modelBuilder.Entity<devteam>()
                .HasMany(e => e.project)
                .WithMany(e => e.devteam)
                .Map(m => m.ToTable("devteam_project").MapLeftKey("devTeam_idTeam"));

            modelBuilder.Entity<employe>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<expensesrecover>()
                .Property(e => e.approve)
                .IsUnicode(false);

            modelBuilder.Entity<expensesrecover>()
                .Property(e => e.feedBacks)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.domaineFormation)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.titleFormation)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .HasMany(e => e.test)
                .WithOptional(e => e.formation)
                .HasForeignKey(e => e.formation_idFormation);

            modelBuilder.Entity<former>()
                .Property(e => e.lastNameFormer)
                .IsUnicode(false);

            modelBuilder.Entity<former>()
                .Property(e => e.nameFormer)
                .IsUnicode(false);

            modelBuilder.Entity<former>()
                .Property(e => e.specialty)
                .IsUnicode(false);

            modelBuilder.Entity<former>()
                .HasMany(e => e.formation)
                .WithOptional(e => e.former)
                .HasForeignKey(e => e.former_idFormer);

            modelBuilder.Entity<project>()
                .Property(e => e.projectName)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.task)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_idProject);

            modelBuilder.Entity<question>()
                .Property(e => e.quesText)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .HasMany(e => e.reponse)
                .WithOptional(e => e.question)
                .HasForeignKey(e => e.quest_idQues);

            modelBuilder.Entity<reclamationfrais>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<reclamationfrais>()
                .Property(e => e.periority)
                .IsUnicode(false);

            modelBuilder.Entity<reclamationfrais>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<reponse>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<task>()
                .HasMany(e => e.workedon)
                .WithRequired(e => e.task)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<test>()
                .Property(e => e.descriptionTest)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.titeTest)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .HasMany(e => e.question)
                .WithOptional(e => e.test)
                .HasForeignKey(e => e.testt_idTest);
        }
    }
}
