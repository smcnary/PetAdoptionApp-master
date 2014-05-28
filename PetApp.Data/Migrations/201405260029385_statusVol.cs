namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusVol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteers", "Status");
        }
    }
}
