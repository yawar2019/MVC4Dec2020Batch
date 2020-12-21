namespace CodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeModels", "DeptName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeModels", "DeptName");
        }
    }
}
