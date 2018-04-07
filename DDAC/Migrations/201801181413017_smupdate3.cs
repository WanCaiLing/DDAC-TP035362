namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smupdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ships", "RemainingCargoSize", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ships", "RemainingCargoSize");
        }
    }
}
