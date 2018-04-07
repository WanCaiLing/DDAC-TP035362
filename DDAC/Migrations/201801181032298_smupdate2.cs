namespace DDAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smupdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookModels", "ContainerModel_Id", "dbo.ContainerModels");
            DropIndex("dbo.BookModels", new[] { "ContainerModel_Id" });
            AddColumn("dbo.ContainerModels", "BookModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContainerModels", "BookModelId");
            AddForeignKey("dbo.ContainerModels", "BookModelId", "dbo.BookModels", "Id", cascadeDelete: true);
            DropColumn("dbo.BookModels", "ContainerId");
            DropColumn("dbo.BookModels", "ContainerModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookModels", "ContainerModel_Id", c => c.Int());
            AddColumn("dbo.BookModels", "ContainerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ContainerModels", "BookModelId", "dbo.BookModels");
            DropIndex("dbo.ContainerModels", new[] { "BookModelId" });
            DropColumn("dbo.ContainerModels", "BookModelId");
            CreateIndex("dbo.BookModels", "ContainerModel_Id");
            AddForeignKey("dbo.BookModels", "ContainerModel_Id", "dbo.ContainerModels", "Id");
        }
    }
}
