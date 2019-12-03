namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wassim : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "pidevds.avis",
                c => new
                    {
                        idEmp = c.Int(nullable: false),
                        idFor = c.Int(nullable: false),
                        commentaire = c.String(maxLength: 255, unicode: false),
                        cin = c.Int(),
                        idFormation = c.Int(),
                    })
                .PrimaryKey(t => new { t.idEmp, t.idFor })
                .ForeignKey("pidevds.employe", t => t.cin)
                .ForeignKey("pidevds.formation", t => t.idFormation)
                .Index(t => t.cin)
                .Index(t => t.idFormation);
            
            CreateTable(
                "pidevds.employe",
                c => new
                    {
                        cin = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 255, unicode: false),
                        birthDate = c.DateTime(),
                        email = c.String(maxLength: 255, unicode: false),
                        firstName = c.String(maxLength: 255, unicode: false),
                        hiringDate = c.DateTime(),
                        lastName = c.String(maxLength: 255, unicode: false),
                        phoneNb = c.Int(nullable: false),
                        role = c.String(maxLength: 255, unicode: false),
                        salary = c.Single(nullable: false),
                        devTeam_idTeam = c.Int(),
                    })
                .PrimaryKey(t => t.cin)
                .ForeignKey("pidevds.devteam", t => t.devTeam_idTeam)
                .Index(t => t.devTeam_idTeam);
            
            CreateTable(
                "pidevds.devteam",
                c => new
                    {
                        idTeam = c.Int(nullable: false, identity: true),
                        Tech = c.String(maxLength: 255, unicode: false),
                        technologie = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idTeam);
            
            CreateTable(
                "pidevds.project",
                c => new
                    {
                        idProject = c.Int(nullable: false, identity: true),
                        DeadLine = c.DateTime(),
                        LaunchedOn = c.DateTime(),
                        projectName = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idProject);
            
            CreateTable(
                "pidevds.task",
                c => new
                    {
                        idTask = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        status = c.String(maxLength: 255, unicode: false),
                        title = c.String(maxLength: 255, unicode: false),
                        project_idProject = c.Int(),
                    })
                .PrimaryKey(t => t.idTask)
                .ForeignKey("pidevds.project", t => t.project_idProject)
                .Index(t => t.project_idProject);
            
            CreateTable(
                "pidevds.workedon",
                c => new
                    {
                        idEmp = c.Int(nullable: false),
                        idTask = c.Int(nullable: false),
                        beginingOn = c.DateTime(),
                        endingOn = c.DateTime(),
                        cin = c.Int(),
                    })
                .PrimaryKey(t => new { t.idEmp, t.idTask })
                .ForeignKey("pidevds.employe", t => t.cin)
                .ForeignKey("pidevds.task", t => t.idTask)
                .Index(t => t.idTask)
                .Index(t => t.cin);
            
            CreateTable(
                "pidevds.formation",
                c => new
                    {
                        idFormation = c.Int(nullable: false, identity: true),
                        dateDebut = c.DateTime(storeType: "date"),
                        dateFin = c.DateTime(storeType: "date"),
                        domaineFormation = c.String(maxLength: 255, unicode: false),
                        titleFormation = c.String(maxLength: 255, unicode: false),
                        former_idFormer = c.Int(),
                    })
                .PrimaryKey(t => t.idFormation)
                .ForeignKey("pidevds.former", t => t.former_idFormer)
                .Index(t => t.former_idFormer);
            
            CreateTable(
                "pidevds.former",
                c => new
                    {
                        idFormer = c.Int(nullable: false, identity: true),
                        lastNameFormer = c.String(maxLength: 255, unicode: false),
                        nameFormer = c.String(maxLength: 255, unicode: false),
                        specialty = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idFormer);
            
            CreateTable(
                "pidevds.test",
                c => new
                    {
                        idTest = c.Int(nullable: false, identity: true),
                        descriptionTest = c.String(maxLength: 255, unicode: false),
                        titeTest = c.String(maxLength: 255, unicode: false),
                        formation_idFormation = c.Int(),
                    })
                .PrimaryKey(t => t.idTest)
                .ForeignKey("pidevds.formation", t => t.formation_idFormation)
                .Index(t => t.formation_idFormation);
            
            CreateTable(
                "pidevds.question",
                c => new
                    {
                        idQues = c.Int(nullable: false, identity: true),
                        quesText = c.String(maxLength: 255, unicode: false),
                        testt_idTest = c.Int(),
                    })
                .PrimaryKey(t => t.idQues)
                .ForeignKey("pidevds.test", t => t.testt_idTest)
                .Index(t => t.testt_idTest);
            
            CreateTable(
                "pidevds.reponse",
                c => new
                    {
                        idRep = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        isValide = c.Boolean(),
                        quest_idQues = c.Int(),
                    })
                .PrimaryKey(t => t.idRep)
                .ForeignKey("pidevds.question", t => t.quest_idQues)
                .Index(t => t.quest_idQues);
            
            CreateTable(
                "pidevds.client",
                c => new
                    {
                        idCl = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255, unicode: false),
                        address = c.String(maxLength: 255, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        phNb = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCl);
            
            CreateTable(
                "pidevds.demande",
                c => new
                    {
                        idDe = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        expenses = c.Single(nullable: false),
                        missionAdress = c.String(maxLength: 255, unicode: false),
                        otherExpenses = c.Single(nullable: false),
                        reservationDate = c.DateTime(),
                        statusF = c.String(maxLength: 255, unicode: false),
                        ticketImg = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idDe);
            
            CreateTable(
                "pidevds.expensesrecover",
                c => new
                    {
                        idEx = c.Int(nullable: false, identity: true),
                        amountCeiling = c.Single(nullable: false),
                        approve = c.String(maxLength: 255, unicode: false),
                        feedBacks = c.String(maxLength: 255, unicode: false),
                        meetingDate = c.DateTime(),
                        recoveredExpenses = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.idEx);
            
            CreateTable(
                "pidevds.reclamationfrais",
                c => new
                    {
                        idRec = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        periority = c.String(maxLength: 255, unicode: false),
                        type = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idRec);
            
            CreateTable(
                "dbo.devteam_project",
                c => new
                    {
                        devTeam_idTeam = c.Int(nullable: false),
                        project_idProject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.devTeam_idTeam, t.project_idProject })
                .ForeignKey("pidevds.devteam", t => t.devTeam_idTeam, cascadeDelete: true)
                .ForeignKey("pidevds.project", t => t.project_idProject, cascadeDelete: true)
                .Index(t => t.devTeam_idTeam)
                .Index(t => t.project_idProject);
            
        }
        
        public override void Down()
        {
            DropForeignKey("pidevds.test", "formation_idFormation", "pidevds.formation");
            DropForeignKey("pidevds.question", "testt_idTest", "pidevds.test");
            DropForeignKey("pidevds.reponse", "quest_idQues", "pidevds.question");
            DropForeignKey("pidevds.formation", "former_idFormer", "pidevds.former");
            DropForeignKey("pidevds.avis", "idFormation", "pidevds.formation");
            DropForeignKey("dbo.devteam_project", "project_idProject", "pidevds.project");
            DropForeignKey("dbo.devteam_project", "devTeam_idTeam", "pidevds.devteam");
            DropForeignKey("pidevds.task", "project_idProject", "pidevds.project");
            DropForeignKey("pidevds.workedon", "idTask", "pidevds.task");
            DropForeignKey("pidevds.workedon", "cin", "pidevds.employe");
            DropForeignKey("pidevds.employe", "devTeam_idTeam", "pidevds.devteam");
            DropForeignKey("pidevds.avis", "cin", "pidevds.employe");
            DropIndex("dbo.devteam_project", new[] { "project_idProject" });
            DropIndex("dbo.devteam_project", new[] { "devTeam_idTeam" });
            DropIndex("pidevds.reponse", new[] { "quest_idQues" });
            DropIndex("pidevds.question", new[] { "testt_idTest" });
            DropIndex("pidevds.test", new[] { "formation_idFormation" });
            DropIndex("pidevds.formation", new[] { "former_idFormer" });
            DropIndex("pidevds.workedon", new[] { "cin" });
            DropIndex("pidevds.workedon", new[] { "idTask" });
            DropIndex("pidevds.task", new[] { "project_idProject" });
            DropIndex("pidevds.employe", new[] { "devTeam_idTeam" });
            DropIndex("pidevds.avis", new[] { "idFormation" });
            DropIndex("pidevds.avis", new[] { "cin" });
            DropTable("dbo.devteam_project");
            DropTable("pidevds.reclamationfrais");
            DropTable("pidevds.expensesrecover");
            DropTable("pidevds.demande");
            DropTable("pidevds.client");
            DropTable("pidevds.reponse");
            DropTable("pidevds.question");
            DropTable("pidevds.test");
            DropTable("pidevds.former");
            DropTable("pidevds.formation");
            DropTable("pidevds.workedon");
            DropTable("pidevds.task");
            DropTable("pidevds.project");
            DropTable("pidevds.devteam");
            DropTable("pidevds.employe");
            DropTable("pidevds.avis");
        }
    }
}
