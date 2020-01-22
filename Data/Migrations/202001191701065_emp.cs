namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.employe", "password", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            AlterColumn("dbo.employe", "email", c => c.String(nullable: false, maxLength: 255, storeType: "nvarchar"));
            DropColumn("dbo.employe", "DTYPE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.employe", "DTYPE", c => c.String(nullable: false, maxLength: 31, storeType: "nvarchar"));
            AlterColumn("dbo.employe", "email", c => c.String(maxLength: 255, storeType: "nvarchar"));
           
        }
    }
}
