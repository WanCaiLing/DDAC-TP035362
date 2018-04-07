namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "contactNum", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.CustomerModels", "agentName", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "OriginalPlace", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "DestinationPlace", c => c.String(nullable: false));
            AlterColumn("dbo.Ships", "ShipName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Ships", "ShipDestination", c => c.String(nullable: false));
            AlterColumn("dbo.Ships", "ShipStartingPoint", c => c.String(nullable: false));
            AlterColumn("dbo.ContainerModels", "ContainerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContainerModels", "ContainerName", c => c.String());
            AlterColumn("dbo.Ships", "ShipStartingPoint", c => c.String());
            AlterColumn("dbo.Ships", "ShipDestination", c => c.String());
            AlterColumn("dbo.Ships", "ShipName", c => c.String());
            AlterColumn("dbo.Schedules", "DestinationPlace", c => c.String());
            AlterColumn("dbo.Schedules", "OriginalPlace", c => c.String());
            AlterColumn("dbo.CustomerModels", "agentName", c => c.String());
            AlterColumn("dbo.CustomerModels", "contactNum", c => c.String(nullable: false));
        }
    }
}
