namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            Sql("delete from dbo.Ships where Id = 5");
            Sql("SET IDENTITY_INSERT dbo.Ships ON");
            Sql("insert into dbo.Ships (Id, ShipName, ShipDestination, ShipStartingPoint, CargoSize) VALUES (4, 'Mayflower', 'Singapore', 'Malaysia', 100)");
            Sql("insert into dbo.Ships(Id, ShipName, ShipDestination, ShipStartingPoint, CargoSize) VALUES(5, 'Merry Go Round', 'Korea', 'India', 50)");
        }
        
        public override void Down()
        {
        }
    }
}
