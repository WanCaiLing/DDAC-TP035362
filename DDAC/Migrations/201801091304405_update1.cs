namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            Sql("delete from dbo.Ships where Id = 3");
            AlterColumn("dbo.Ships", "CargoSize", c => c.Int(nullable: false));
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ships", "CargoSize", c => c.String());
        }
    }
}
