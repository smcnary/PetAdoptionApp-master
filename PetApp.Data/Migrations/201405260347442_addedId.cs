namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Volunteers", "Detail_Id", "dbo.Details");
            DropIndex("dbo.Volunteers", new[] { "Detail_Id" });
            RenameColumn(table: "dbo.Volunteers", name: "Detail_Id", newName: "DetailId");
            AlterColumn("dbo.Volunteers", "DetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.Volunteers", "DetailId");
            AddForeignKey("dbo.Volunteers", "DetailId", "dbo.Details", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Volunteers", "DetailId", "dbo.Details");
            DropIndex("dbo.Volunteers", new[] { "DetailId" });
            AlterColumn("dbo.Volunteers", "DetailId", c => c.Int());
            RenameColumn(table: "dbo.Volunteers", name: "DetailId", newName: "Detail_Id");
            CreateIndex("dbo.Volunteers", "Detail_Id");
            AddForeignKey("dbo.Volunteers", "Detail_Id", "dbo.Details", "Id");
        }
    }
}
