namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetClassUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "Shelter_Id", "dbo.Shelters");
            DropIndex("dbo.Pets", new[] { "Shelter_Id" });
            RenameColumn(table: "dbo.Pets", name: "Shelter_Id", newName: "ShelterId");
            AlterColumn("dbo.Pets", "ShelterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "ShelterId");
            AddForeignKey("dbo.Pets", "ShelterId", "dbo.Shelters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "ShelterId", "dbo.Shelters");
            DropIndex("dbo.Pets", new[] { "ShelterId" });
            AlterColumn("dbo.Pets", "ShelterId", c => c.Int());
            RenameColumn(table: "dbo.Pets", name: "ShelterId", newName: "Shelter_Id");
            CreateIndex("dbo.Pets", "Shelter_Id");
            AddForeignKey("dbo.Pets", "Shelter_Id", "dbo.Shelters", "Id");
        }
    }
}
