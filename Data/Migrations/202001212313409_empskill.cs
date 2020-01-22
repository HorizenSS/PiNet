namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empskill : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("EmployeeSkills");
            AddPrimaryKey("EmployeeSkills", new[] { "employeFK", "skillFK" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("mployeeSkills");
            AddPrimaryKey("EmployeeSkills", new[] { "DateAssigned", "employeFK", "skillFK" });
        }
    }
}
