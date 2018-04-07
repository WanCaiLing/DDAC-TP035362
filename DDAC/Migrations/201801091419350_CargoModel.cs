namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CargoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipDepartureDate = c.DateTime(nullable: false),
                        ShipArrivalDate = c.DateTime(nullable: false),
                        OriginalPlace = c.String(),
                        DestinationPlace = c.String(),
                        ShipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ships", t => t.ShipId, cascadeDelete: true)
                .Index(t => t.ShipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "ShipId", "dbo.Ships");
            DropIndex("dbo.Schedules", new[] { "ShipId" });
            DropTable("dbo.Schedules");
        }
    }
}
