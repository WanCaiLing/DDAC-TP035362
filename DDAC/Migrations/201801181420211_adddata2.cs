namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddata2 : DbMigration
    {
        public override void Up()
        {
            Sql("update dbo.Ships set RemainingCargoSize = " + 60 + "where Id = " + 2 + "");
            Sql("update dbo.Ships set RemainingCargoSize = " + 200 + "where Id = " + 3 + "");
            Sql("update dbo.Ships set RemainingCargoSize = " + 100 + "where Id = " + 4 + "");
            Sql("update dbo.Ships set RemainingCargoSize = " + 50 + "where Id = " + 5 + "");
            Sql("update dbo.Ships set RemainingCargoSize = " + 30 + "where Id = " + 6 + "");
            Sql("update dbo.Ships set RemainingCargoSize = " + 100 + "where Id = " + 7 + "");
            Sql("update dbo.Ships set CargoSize = " + 100 + ", RemainingCargoSize = " + 100 + "where Id = " + 8 + "");
            Sql("update dbo.Ships set RemainingCargoSize = " + 100 + "where Id = " + 9 + "");
            Sql("update dbo.Ships set RemainingCargoSize = " + 200 + "where Id = " + 10 + "");
            Sql("update dbo.Ships set RemainingCargoSize = " + 100 + "where Id = " + 11 + "");
            Sql("update dbo.Ships set CargoSize = " + 100 + ", RemainingCargoSize = " + 100 + "where Id = " + 12 + "");

        }

        public override void Down()
        {
        }
    }
}
