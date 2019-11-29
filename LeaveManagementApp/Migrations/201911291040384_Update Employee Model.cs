namespace LeaveManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Designation", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "ContactNo", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "JoinDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "IsConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "IsConfirmed");
            DropColumn("dbo.Employees", "IsActive");
            DropColumn("dbo.Employees", "JoinDate");
            DropColumn("dbo.Employees", "ContactNo");
            DropColumn("dbo.Employees", "DateOfBirth");
            DropColumn("dbo.Employees", "Designation");
            DropColumn("dbo.Employees", "Email");
        }
    }
}
