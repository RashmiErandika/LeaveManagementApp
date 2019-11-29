namespace LeaveManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelstodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeLeaveCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LeaveTypeId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        EntitleCount = c.Int(nullable: false),
                        RemainCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Leaves", t => t.LeaveTypeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.LeaveTypeId);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveType = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeLeaveCounts", "LeaveTypeId", "dbo.Leaves");
            DropForeignKey("dbo.EmployeeLeaveCounts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeLeaveCounts", new[] { "LeaveTypeId" });
            DropIndex("dbo.EmployeeLeaveCounts", new[] { "EmployeeId" });
            DropTable("dbo.Leaves");
            DropTable("dbo.EmployeeLeaveCounts");
        }
    }
}
