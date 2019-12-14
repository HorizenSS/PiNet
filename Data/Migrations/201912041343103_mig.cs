namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.positionOffers", "Description", c => c.String(unicode: false));
            AlterColumn("dbo.positionOffers", "Name", c => c.String(unicode: false));
            AlterColumn("dbo.positionOffers", "Priority", c => c.String(unicode: false));
            AlterColumn("dbo.positionOffers", "Type", c => c.String(unicode: false));
            AlterColumn("dbo.positionSkills", "Description", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.positionSkills", "Description", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.positionOffers", "Type", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.positionOffers", "Priority", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.positionOffers", "Name", c => c.String(maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.positionOffers", "Description", c => c.String(maxLength: 255, storeType: "nvarchar"));
        }
    }
}
