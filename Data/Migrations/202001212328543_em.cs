namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class em : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("EmployeeSkills");
            AddPrimaryKey("EmployeeSkills", new[] { "employeFK", "skillFK" });
            DropColumn("EmployeeSkills", "empskId");
        }
        
        public override void Down()
        {
            AddColumn("EmployeeSkills", "empskId", c => c.Int(nullable: false));
            DropPrimaryKey("EmployeeSkills");
            AddPrimaryKey("EmployeeSkills", new[] { "empskId", "employeFK", "skillFK" });
        }
    }
}
