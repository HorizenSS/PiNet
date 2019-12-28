namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
  
          
            
            CreateTable(
                "dbo.ticketOcr",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(unicode: false),
                        ArticlesDetails = c.String(unicode: false),
                        Totale = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.qualification", "idJobOffer", "dbo.jobOffer");
            DropForeignKey("dbo.qualification", "cin", "dbo.employe");
            DropForeignKey("dbo.jobOffer", "cin", "dbo.employe");
            DropIndex("dbo.qualification", new[] { "cin" });
            DropIndex("dbo.qualification", new[] { "idJobOffer" });
            DropIndex("dbo.jobOffer", new[] { "cin" });
            DropTable("dbo.ticketOcr");
            DropTable("dbo.skill");
            DropTable("dbo.qualification");
            DropTable("dbo.jobOffer");
            DropTable("dbo.employe");
        }
    }
}
