namespace LeaveManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaveRequestAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Leave_Type = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leaves", t => t.Leave_Type, cascadeDelete: true)
                .Index(t => t.Leave_Type);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeaveRequests", "Leave_Type", "dbo.Leaves");
            DropIndex("dbo.LeaveRequests", new[] { "Leave_Type" });
            DropTable("dbo.LeaveRequests");
        }
    }
}
