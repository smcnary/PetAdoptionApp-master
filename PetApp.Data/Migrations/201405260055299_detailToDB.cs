namespace PetApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detailToDB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Volunteers", name: "Details_Id", newName: "Detail_Id");
            RenameIndex(table: "dbo.Volunteers", name: "IX_Details_Id", newName: "IX_Detail_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Volunteers", name: "IX_Detail_Id", newName: "IX_Details_Id");
            RenameColumn(table: "dbo.Volunteers", name: "Detail_Id", newName: "Details_Id");
        }
    }
}
