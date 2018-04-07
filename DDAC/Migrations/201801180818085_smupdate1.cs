namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smupdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "customerName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "customerName", c => c.String(nullable: false));
        }
    }
}
