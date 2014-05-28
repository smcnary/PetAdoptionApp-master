namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRequestedStart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "RequestedStart", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteers", "RequestedStart");
        }
    }
}
