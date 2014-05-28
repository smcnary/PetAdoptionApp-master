namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detailsVolunteer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Volunteers", "Details_Id", c => c.Int());
            CreateIndex("dbo.Volunteers", "Details_Id");
            AddForeignKey("dbo.Volunteers", "Details_Id", "dbo.Details", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Volunteers", "Details_Id", "dbo.Details");
            DropIndex("dbo.Volunteers", new[] { "Details_Id" });
            DropColumn("dbo.Volunteers", "Details_Id");
            DropTable("dbo.Details");
        }
    }
}
