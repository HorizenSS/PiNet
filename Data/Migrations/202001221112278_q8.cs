namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class q8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TargetSkills",
                c => new
                    {
                        targetId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                        idJobOffer = c.Int(nullable: false),
                        DeadLine = c.DateTime(precision: 0),
                        StartDate = c.DateTime(precision: 0),
                        state = c.Int(nullable: false),
                        cin = c.Int(),
                    })
                .PrimaryKey(t => t.targetId)
                .ForeignKey("dbo.employe", t => t.cin)
                .ForeignKey("dbo.jobOffer", t => t.idJobOffer, cascadeDelete: true)
                .Index(t => t.idJobOffer)
                .Index(t => t.cin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TargetSkills", "idJobOffer", "dbo.jobOffer");
            DropForeignKey("dbo.TargetSkills", "cin", "dbo.employe");
            DropIndex("dbo.TargetSkills", new[] { "cin" });
            DropIndex("dbo.TargetSkills", new[] { "idJobOffer" });
            DropTable("dbo.TargetSkills");
        }
    }
}
