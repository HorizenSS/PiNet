namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lina : DbMigration
    {
        public override void Up()
        {
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
                "pidevds.devteam",
                c => new
                    {
                        idTeam = c.Int(nullable: false, identity: true),
                        Tech = c.String(maxLength: 255, unicode: false),
                        technologie = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idTeam);
            
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
                "pidevds.test",
                c => new
                    {
                        idEmp = c.Int(nullable: false),
                        idFor = c.Int(nullable: false),
                        idTest = c.Int(nullable: false),
                        Speciality = c.String(maxLength: 255, unicode: false),
                        score = c.String(maxLength: 255, unicode: false),
                        titeTest = c.String(maxLength: 255, unicode: false),
                        cin = c.Int(),
                        idFormation = c.Int(),
                    })
                .PrimaryKey(t => new { t.idEmp, t.idFor, t.idTest })
                .ForeignKey("pidevds.employe", t => t.cin)
                .ForeignKey("pidevds.formation", t => t.idFormation)
                .Index(t => t.cin)
                .Index(t => t.idFormation);
            
            CreateTable(
                "pidevds.formation",
                c => new
                    {
                        idFormation = c.Int(nullable: false, identity: true),
                        dateDebut = c.DateTime(),
                        dateFin = c.DateTime(),
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
                "pidevds.settings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        breakTime_hours = c.Int(nullable: false),
                        breakTime_minutes = c.Int(nullable: false),
                        dailyLimit_hours = c.Int(nullable: false),
                        dailyLimit_minutes = c.Int(nullable: false),
                        doubleOvertimeRate = c.Double(nullable: false),
                        overtimeRate = c.Double(nullable: false),
                        regularRate = c.Double(nullable: false),
                        weeklyLimit_hours = c.Int(nullable: false),
                        weeklyLimit_minutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pidevds.timesheet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        clock_in = c.Time(precision: 7),
                        clock_out = c.Time(precision: 7),
                        day = c.DateTime(storeType: "date"),
                        owner_id = c.Int(),
                        settings_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidevds.user", t => t.owner_id)
                .ForeignKey("pidevds.settings", t => t.settings_id)
                .Index(t => t.owner_id)
                .Index(t => t.settings_id);
            
            CreateTable(
                "pidevds.user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(maxLength: 255, unicode: false),
                        LastName = c.String(maxLength: 255, unicode: false),
                        Phone = c.String(maxLength: 255, unicode: false),
                        cin = c.String(maxLength: 255, unicode: false),
                        grade = c.String(maxLength: 255, unicode: false),
                        login = c.String(maxLength: 255, unicode: false),
                        mail = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        rating = c.Int(nullable: false),
                        role = c.String(maxLength: 255, unicode: false),
                        salary = c.Double(),
                        speciality = c.String(maxLength: 255, unicode: false),
                        manager_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidevds.user", t => t.manager_id)
                .Index(t => t.manager_id);
            
            CreateTable(
                "pidevds.ticket",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        assignement = c.Boolean(nullable: false),
                        date = c.DateTime(storeType: "date"),
                        description = c.String(unicode: false),
                        estimatedHours = c.Int(nullable: false),
                        status = c.String(),
                        title = c.String(unicode: false),
                        employee_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidevds.user", t => t.employee_id)
                .Index(t => t.employee_id);
            
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
            DropForeignKey("pidevds.timesheet", "settings_id", "pidevds.settings");
            DropForeignKey("pidevds.user", "manager_id", "pidevds.user");
            DropForeignKey("pidevds.timesheet", "owner_id", "pidevds.user");
            DropForeignKey("pidevds.ticket", "employee_id", "pidevds.user");
            DropForeignKey("dbo.devteam_project", "project_idProject", "pidevds.project");
            DropForeignKey("dbo.devteam_project", "devTeam_idTeam", "pidevds.devteam");
            DropForeignKey("pidevds.employe", "devTeam_idTeam", "pidevds.devteam");
            DropForeignKey("pidevds.workedon", "idTask", "pidevds.task");
            DropForeignKey("pidevds.task", "project_idProject", "pidevds.project");
            DropForeignKey("pidevds.workedon", "cin", "pidevds.employe");
            DropForeignKey("pidevds.test", "idFormation", "pidevds.formation");
            DropForeignKey("pidevds.formation", "former_idFormer", "pidevds.former");
            DropForeignKey("pidevds.test", "cin", "pidevds.employe");
            DropIndex("dbo.devteam_project", new[] { "project_idProject" });
            DropIndex("dbo.devteam_project", new[] { "devTeam_idTeam" });
            DropIndex("pidevds.ticket", new[] { "employee_id" });
            DropIndex("pidevds.user", new[] { "manager_id" });
            DropIndex("pidevds.timesheet", new[] { "settings_id" });
            DropIndex("pidevds.timesheet", new[] { "owner_id" });
            DropIndex("pidevds.task", new[] { "project_idProject" });
            DropIndex("pidevds.workedon", new[] { "cin" });
            DropIndex("pidevds.workedon", new[] { "idTask" });
            DropIndex("pidevds.formation", new[] { "former_idFormer" });
            DropIndex("pidevds.test", new[] { "idFormation" });
            DropIndex("pidevds.test", new[] { "cin" });
            DropIndex("pidevds.employe", new[] { "devTeam_idTeam" });
            DropTable("dbo.devteam_project");
            DropTable("pidevds.ticket");
            DropTable("pidevds.user");
            DropTable("pidevds.timesheet");
            DropTable("pidevds.settings");
            DropTable("pidevds.reclamationfrais");
            DropTable("pidevds.expensesrecover");
            DropTable("pidevds.project");
            DropTable("pidevds.task");
            DropTable("pidevds.workedon");
            DropTable("pidevds.former");
            DropTable("pidevds.formation");
            DropTable("pidevds.test");
            DropTable("pidevds.employe");
            DropTable("pidevds.devteam");
            DropTable("pidevds.demande");
            DropTable("pidevds.client");
        }
    }
}
