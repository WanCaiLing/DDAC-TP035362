namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddata : DbMigration
    {
        public override void Up()
        {
            Sql("update dbo.Ships set RemainingCargoSize = "+50+"where Id = "+1+"");
        }
        
        public override void Down()
        {
        }
    }
}
