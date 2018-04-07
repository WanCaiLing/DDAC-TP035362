namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCustomerController : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "icNum", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerModels", "contactNum", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "contactNum", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.CustomerModels", "icNum", c => c.String(nullable: false, maxLength: 14));
        }
    }
}
