namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shelters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pets", "Shelter_Id", c => c.Int());
            CreateIndex("dbo.Pets", "Shelter_Id");
            AddForeignKey("dbo.Pets", "Shelter_Id", "dbo.Shelters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "Shelter_Id", "dbo.Shelters");
            DropIndex("dbo.Pets", new[] { "Shelter_Id" });
            DropColumn("dbo.Pets", "Shelter_Id");
            DropTable("dbo.Shelters");
        }
    }
}
