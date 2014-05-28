namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduleTimeSpan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Booked", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "Booked");
        }
    }
}
