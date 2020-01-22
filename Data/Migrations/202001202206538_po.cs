namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class po : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            DropTable("pidevds.jobofferskills");
        }
    }
}
