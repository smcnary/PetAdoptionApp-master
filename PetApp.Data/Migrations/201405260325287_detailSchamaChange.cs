namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detailSchamaChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "SDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Details", "STime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Details", "EDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Details", "ETime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Details", "StartTime");
            DropColumn("dbo.Details", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Details", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Details", "ETime");
            DropColumn("dbo.Details", "EDate");
            DropColumn("dbo.Details", "STime");
            DropColumn("dbo.Details", "SDate");
        }
    }
}
