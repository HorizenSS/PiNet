namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSkills",
                c => new
                    {
                        DateAssigned = c.DateTime(nullable: false, precision: 0),
                        employeFK = c.Int(nullable: false),
                        skillFK = c.Int(nullable: false),
                        Description = c.String(maxLength: 255, unicode: false),
                        level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DateAssigned, t.employeFK, t.skillFK })
                .ForeignKey("dbo.employe", t => t.employeFK, cascadeDelete: true)
                .ForeignKey("dbo.skill", t => t.skillFK, cascadeDelete: true)
                .Index(t => t.employeFK)
                .Index(t => t.skillFK);
            
            CreateTable(
                "dbo.employe",
                c => new
                    {
                        cin = c.Int(nullable: false, identity: true),
                        DTYPE = c.String(nullable: false, maxLength: 31, storeType: "nvarchar"),
                        Address = c.String(maxLength: 255, storeType: "nvarchar"),
                        birthDate = c.DateTime(precision: 0),
                        email = c.String(maxLength: 255, storeType: "nvarchar"),
                        firstName = c.String(maxLength: 255, storeType: "nvarchar"),
                        hiringDate = c.DateTime(precision: 0),
                        lastName = c.String(maxLength: 255, storeType: "nvarchar"),
                        phoneNb = c.Int(nullable: false),
                        role = c.String(maxLength: 255, storeType: "nvarchar"),
                        salary = c.Single(nullable: false),
                        devTeam_idTeam = c.Int(),
                        resumeId = c.Int(),
                    })
                .PrimaryKey(t => t.cin);
            
            CreateTable(
                "dbo.skill",
                c => new
                    {
                        skillId = c.Int(nullable: false, identity: true),
                        category = c.String(maxLength: 255, unicode: false),
                        name = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.skillId);
            
            CreateTable(
                "dbo.jobOffer",
                c => new
                    {
                        IdJobOffer = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 255, unicode: false),
                        EndDate = c.DateTime(precision: 0),
                        Name = c.String(maxLength: 255, unicode: false),
                        salary = c.Int(nullable: false),
                        StartDate = c.DateTime(precision: 0),
                        DocumentsUrl = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.IdJobOffer);
            
            CreateTable(
                "dbo.qualification",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                        idJobOffer = c.Int(nullable: false),
                        DeadLine = c.DateTime(precision: 0),
                        StartDate = c.DateTime(precision: 0),
                        state = c.String(maxLength: 255, storeType: "nvarchar"),
                        cin = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.employe", t => t.cin)
                .ForeignKey("dbo.jobOffer", t => t.idJobOffer, cascadeDelete: true)
                .Index(t => t.idJobOffer)
                .Index(t => t.cin);
            
            CreateTable(
                "dbo.ticketOcr",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(maxLength: 255, storeType: "nvarchar"),
                        ArticlesDetails = c.String(maxLength: 255, storeType: "nvarchar"),
                        Totale = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.qualification", "idJobOffer", "dbo.jobOffer");
            DropForeignKey("dbo.qualification", "cin", "dbo.employe");
            DropForeignKey("dbo.EmployeeSkills", "skillFK", "dbo.skill");
            DropForeignKey("dbo.EmployeeSkills", "employeFK", "dbo.employe");
            DropIndex("dbo.qualification", new[] { "cin" });
            DropIndex("dbo.qualification", new[] { "idJobOffer" });
            DropIndex("dbo.EmployeeSkills", new[] { "skillFK" });
            DropIndex("dbo.EmployeeSkills", new[] { "employeFK" });
            DropTable("dbo.ticketOcr");
            DropTable("dbo.qualification");
            DropTable("dbo.jobOffer");
            DropTable("dbo.skill");
            DropTable("dbo.employe");
            DropTable("dbo.EmployeeSkills");
        }
    }
}
