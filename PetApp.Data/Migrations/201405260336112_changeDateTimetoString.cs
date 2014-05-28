namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDateTimetoString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "StartDate", c => c.String());
            AddColumn("dbo.Details", "EndDate", c => c.String());
            DropColumn("dbo.Details", "SDate");
            DropColumn("dbo.Details", "STime");
            DropColumn("dbo.Details", "EDate");
            DropColumn("dbo.Details", "ETime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "ETime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Details", "EDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Details", "STime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Details", "SDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Details", "EndDate");
            DropColumn("dbo.Details", "StartDate");
        }
    }
}
