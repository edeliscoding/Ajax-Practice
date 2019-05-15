namespace AjaxPost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIcollection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Car_Id", "dbo.Cars");
            DropIndex("dbo.Cars", new[] { "Car_Id" });
            AddColumn("dbo.Cars", "ListString", c => c.String());
            DropColumn("dbo.Cars", "Car_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Car_Id", c => c.Int());
            DropColumn("dbo.Cars", "ListString");
            CreateIndex("dbo.Cars", "Car_Id");
            AddForeignKey("dbo.Cars", "Car_Id", "dbo.Cars", "Id");
        }
    }
}
