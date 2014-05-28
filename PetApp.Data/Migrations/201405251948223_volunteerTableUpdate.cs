namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class volunteerTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Volunteers", "Pet_Id", c => c.Int());
            CreateIndex("dbo.Volunteers", "Pet_Id");
            AddForeignKey("dbo.Volunteers", "Pet_Id", "dbo.Pets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Volunteers", "Pet_Id", "dbo.Pets");
            DropIndex("dbo.Volunteers", new[] { "Pet_Id" });
            DropColumn("dbo.Volunteers", "Pet_Id");
            DropColumn("dbo.Volunteers", "Type");
        }
    }
}
