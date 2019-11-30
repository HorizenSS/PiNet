namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
using PiDev.Domain.Entities;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Context")
        {
        }

        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<demande> demande { get; set; }
        public virtual DbSet<devteam> devteam { get; set; }
        public virtual DbSet<employe> employe { get; set; }
        public virtual DbSet<expensesrecover> expensesrecover { get; set; }
        public virtual DbSet<formation> formation { get; set; }
        public virtual DbSet<former> former { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<reclamationfrais> reclamationfrais { get; set; }
        public virtual DbSet<settings> settings { get; set; }
        public virtual DbSet<task> task { get; set; }
        public virtual DbSet<test> test { get; set; }
        public virtual DbSet<ticket> ticket { get; set; }
        public virtual DbSet<timesheet> timesheet { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<workedon> workedon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<reclamationfrais>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<reclamationfrais>()
                .Property(e => e.periority)
                .IsUnicode(false);

            modelBuilder.Entity<reclamationfrais>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<settings>()
                .HasMany(e => e.timesheet)
                .WithOptional(e => e.settings)
                .HasForeignKey(e => e.settings_id);

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
                .Property(e => e.Speciality)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.score)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.titeTest)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.cin)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.grade)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.speciality)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.ticket)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.employee_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.timesheet)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.owner_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.user1)
                .WithOptional(e => e.user2)
                .HasForeignKey(e => e.manager_id);
        }
    }
}
