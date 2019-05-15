namespace AjaxPost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addListofCars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Car_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Car_Id");
            AddForeignKey("dbo.Cars", "Car_Id", "dbo.Cars", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Car_Id", "dbo.Cars");
            DropIndex("dbo.Cars", new[] { "Car_Id" });
            DropColumn("dbo.Cars", "Car_Id");
        }
    }
}
