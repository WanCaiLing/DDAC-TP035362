namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddata3 : DbMigration
    {
        public override void Up()
        {
            Sql("update dbo.Ships set ShipDestination = 'Malaysia', ShipStartingPoint = 'Vietnam' where Id = " + 8 + "");
            Sql("update dbo.Ships set ShipDestination = 'India', ShipStartingPoint = 'Japan' where Id = " + 12 + "");
        }
        
        public override void Down()
        {
        }
    }
}
