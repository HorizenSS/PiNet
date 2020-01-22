namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empskill1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("EmployeeSkills");
            AddColumn("EmployeeSkills", "empskId", c => c.Int(nullable: false));
            AddPrimaryKey("EmployeeSkills", new[] { "empskId", "employeFK", "skillFK" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("EmployeeSkills");
            DropColumn("EmployeeSkills", "empskId");
            AddPrimaryKey("EmployeeSkills", new[] { "employeFK", "skillFK" });
        }
    }
}
