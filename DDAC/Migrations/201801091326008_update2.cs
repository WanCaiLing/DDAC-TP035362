namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            Sql("delete from dbo.Ships where Id = 4");
            Sql("SET IDENTITY_INSERT dbo.Ships ON");
            Sql("insert into dbo.Ships (Id, ShipName, ShipDestination, ShipStartingPoint, CargoSize) VALUES (3, 'Bay Bay', 'Hong Kong', 'Malaysia', 200)");

        }
        
        public override void Down()
        {
        }
    }
}
