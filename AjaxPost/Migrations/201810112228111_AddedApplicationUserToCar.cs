namespace AjaxPost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedApplicationUserToCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Employee_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cars", "Employee_Id");
            AddForeignKey("dbo.Cars", "Employee_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Employee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "Employee_Id" });
            DropColumn("dbo.Cars", "Employee_Id");
        }
    }
}
