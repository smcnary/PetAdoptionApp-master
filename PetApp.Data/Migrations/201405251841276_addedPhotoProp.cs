namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPhotoProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Photo", c => c.String());
            AddColumn("dbo.Shelters", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shelters", "Photo");
            DropColumn("dbo.Pets", "Photo");
        }
    }
}
