namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "agentName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "agentName", c => c.String(nullable: false));
        }
    }
}
