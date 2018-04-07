namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingandcontainer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        bayVolume = c.Int(nullable: false),
                        customerID = c.Int(nullable: false),
                        scheduleId = c.Int(nullable: false),
                        ContainerId = c.Int(nullable: false),
                        ContainerModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContainerModels", t => t.ContainerModel_Id)
                .ForeignKey("dbo.CustomerModels", t => t.customerID, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.scheduleId, cascadeDelete: true)
                .Index(t => t.customerID)
                .Index(t => t.scheduleId)
                .Index(t => t.ContainerModel_Id);
            
            CreateTable(
                "dbo.ContainerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContainerName = c.String(),
                        BayUsed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookModels", "scheduleId", "dbo.Schedules");
            DropForeignKey("dbo.BookModels", "customerID", "dbo.CustomerModels");
            DropForeignKey("dbo.BookModels", "ContainerModel_Id", "dbo.ContainerModels");
            DropIndex("dbo.BookModels", new[] { "ContainerModel_Id" });
            DropIndex("dbo.BookModels", new[] { "scheduleId" });
            DropIndex("dbo.BookModels", new[] { "customerID" });
            DropTable("dbo.ContainerModels");
            DropTable("dbo.BookModels");
        }
    }
}
