namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipName = c.String(),
                        ShipDestination = c.String(),
                        ShipStartingPoint = c.String(),
                        CargoSize = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ships");
        }
    }
}
