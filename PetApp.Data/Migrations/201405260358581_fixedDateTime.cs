namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedDateTime : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Volunteers", "DetailId", "dbo.Details");
            DropIndex("dbo.Volunteers", new[] { "DetailId" });
            RenameColumn(table: "dbo.Volunteers", name: "DetailId", newName: "Detail_Id");
            AlterColumn("dbo.Details", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Details", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Volunteers", "Detail_Id", c => c.Int());
            CreateIndex("dbo.Volunteers", "Detail_Id");
            AddForeignKey("dbo.Volunteers", "Detail_Id", "dbo.Details", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Volunteers", "Detail_Id", "dbo.Details");
            DropIndex("dbo.Volunteers", new[] { "Detail_Id" });
            AlterColumn("dbo.Volunteers", "Detail_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Details", "EndDate", c => c.String());
            AlterColumn("dbo.Details", "StartDate", c => c.String());
            RenameColumn(table: "dbo.Volunteers", name: "Detail_Id", newName: "DetailId");
            CreateIndex("dbo.Volunteers", "DetailId");
            AddForeignKey("dbo.Volunteers", "DetailId", "dbo.Details", "Id", cascadeDelete: true);
        }
    }
}
