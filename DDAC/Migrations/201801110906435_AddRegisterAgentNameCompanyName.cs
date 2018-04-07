namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegisterAgentNameCompanyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AgentName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "AgentName");
        }
    }
}
