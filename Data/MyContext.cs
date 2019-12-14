namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<competence> competence { get; set; }
        public virtual DbSet<demande> demande { get; set; }
        public virtual DbSet<devteam> devteam { get; set; }
        public virtual DbSet<employe> employe { get; set; }
        public virtual DbSet<expensesrecover> expensesrecover { get; set; }
        public virtual DbSet<formation> formation { get; set; }
        public virtual DbSet<former> former { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<questionresponse> questionresponse { get; set; }
        public virtual DbSet<quizquestion> quizquestion { get; set; }
        public virtual DbSet<reclamationfrais> reclamationfrais { get; set; }
        public virtual DbSet<resume> resume { get; set; }
        public virtual DbSet<skill> skill { get; set; }
        public virtual DbSet<task> task { get; set; }
        public virtual DbSet<test> test { get; set; }
        public virtual DbSet<userfeedback> userfeedback { get; set; }
        public virtual DbSet<userquiz> userquiz { get; set; }
        public virtual DbSet<userquizresponse> userquizresponse { get; set; }
        public virtual DbSet<userskill> userskill { get; set; }
        public virtual DbSet<utilisateur> utilisateur { get; set; }
        public virtual DbSet<workedon> workedon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.skill)
                .WithOptional(e => e.category)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .HasMany(e => e.resume)
                .WithMany(e => e.competence)
                .Map(m => m.ToTable("resume_competence").MapLeftKey("Competences_skillId").MapRightKey("Resume_resumeId"));

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
                .Property(e => e.DTYPE)
                .IsUnicode(false);

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

            modelBuilder.Entity<questionresponse>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<questionresponse>()
                .HasMany(e => e.userquizresponse)
                .WithOptional(e => e.questionresponse)
                .HasForeignKey(e => e.response_id);

            modelBuilder.Entity<quizquestion>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<quizquestion>()
                .HasMany(e => e.questionresponse)
                .WithOptional(e => e.quizquestion)
                .HasForeignKey(e => e.question_id);

            modelBuilder.Entity<reclamationfrais>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<reclamationfrais>()
                .Property(e => e.periority)
                .IsUnicode(false);

            modelBuilder.Entity<reclamationfrais>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<resume>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<resume>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .HasMany(e => e.userskill)
                .WithOptional(e => e.skill)
                .HasForeignKey(e => e.skill_id);

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

            modelBuilder.Entity<userfeedback>()
                .Property(e => e.feedback)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .Property(e => e.cin)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<utilisateur>()
                .HasMany(e => e.userfeedback)
                .WithOptional(e => e.utilisateur)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<utilisateur>()
                .HasMany(e => e.userquiz)
                .WithOptional(e => e.utilisateur)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<utilisateur>()
                .HasMany(e => e.userquizresponse)
                .WithOptional(e => e.utilisateur)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<utilisateur>()
                .HasMany(e => e.userskill)
                .WithOptional(e => e.utilisateur)
                .HasForeignKey(e => e.user_id);
        }
    }
}
