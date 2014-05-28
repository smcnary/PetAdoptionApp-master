namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPetType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pets", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "Type", c => c.String());
        }
    }
}
