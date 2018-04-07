namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgentNameInCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "agentName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "agentName");
        }
    }
}
