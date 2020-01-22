namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.jobOfferskills",
                c => new
                    {
                        jobOffer_IdJobOffer = c.Int(nullable: false),
                        skill_skillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.jobOffer_IdJobOffer, t.skill_skillId })
                .ForeignKey("dbo.jobOffer", t => t.jobOffer_IdJobOffer, cascadeDelete: true)
                .ForeignKey("dbo.skill", t => t.skill_skillId, cascadeDelete: true)
                .Index(t => t.jobOffer_IdJobOffer)
                .Index(t => t.skill_skillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jobOfferskills", "skill_skillId", "dbo.skill");
            DropForeignKey("dbo.jobOfferskills", "jobOffer_IdJobOffer", "dbo.jobOffer");
            DropIndex("dbo.jobOfferskills", new[] { "skill_skillId" });
            DropIndex("dbo.jobOfferskills", new[] { "jobOffer_IdJobOffer" });
            DropTable("dbo.jobOfferskills");
        }
    }
}
