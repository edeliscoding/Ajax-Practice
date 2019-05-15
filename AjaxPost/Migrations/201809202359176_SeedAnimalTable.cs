namespace AjaxPost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAnimalTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Animals (Name) VALUES ('ardvark')");
            Sql("INSERT INTO Animals (Name) VALUES ('Badger')");
            Sql("INSERT INTO Animals (Name) VALUES ('Beetle')");
            Sql("INSERT INTO Animals (Name) VALUES ('Camel')");
            Sql("INSERT INTO Animals (Name) VALUES ('Crow')");
            Sql("INSERT INTO Animals (Name) VALUES ('Dog')");
            Sql("INSERT INTO Animals (Name) VALUES ('Deer')");
            Sql("INSERT INTO Animals (Name) VALUES ('Elephant')");
            Sql("INSERT INTO Animals (Name) VALUES ('Eagle')");
            Sql("INSERT INTO Animals (Name) VALUES ('Frog')");
            Sql("INSERT INTO Animals (Name) VALUES ('Flea')");
            Sql("INSERT INTO Animals (Name) VALUES ('Goat')");
            Sql("INSERT INTO Animals (Name) VALUES ('Gorilla')");
            Sql("INSERT INTO Animals (Name) VALUES ('Horse')");
            Sql("INSERT INTO Animals (Name) VALUES ('Hen')");
            Sql("INSERT INTO Animals (Name) VALUES ('Impala')");
            Sql("INSERT INTO Animals (Name) VALUES ('Jaguar')");
            Sql("INSERT INTO Animals (Name) VALUES ('Jaguaruindi')");
            Sql("INSERT INTO Animals (Name) VALUES ('Jellyfish')");
            Sql("INSERT INTO Animals (Name) VALUES ('Kangaroo')");
            Sql("INSERT INTO Animals (Name) VALUES ('Lama')");
            Sql("INSERT INTO Animals (Name) VALUES ('Monkey')");
            Sql("INSERT INTO Animals (Name) VALUES ('Narwal')");
            Sql("INSERT INTO Animals (Name) VALUES ('Octopus')");
            Sql("INSERT INTO Animals (Name) VALUES ('Peacock')");
            Sql("INSERT INTO Animals (Name) VALUES ('Quetzal')");
            Sql("INSERT INTO Animals (Name) VALUES ('Racoon')");
            Sql("INSERT INTO Animals (Name) VALUES ('Snake')");
            Sql("INSERT INTO Animals (Name) VALUES ('Tiger')");
            Sql("INSERT INTO Animals (Name) VALUES ('Unicorn')");
            Sql("INSERT INTO Animals (Name) VALUES ('Vaquita')");
            Sql("INSERT INTO Animals (Name) VALUES ('Whale')");
            Sql("INSERT INTO Animals (Name) VALUES ('X-ray')");
            Sql("INSERT INTO Animals (Name) VALUES ('Yak')");
            Sql("INSERT INTO Animals (Name) VALUES ('Zebra')");
        }
        
        public override void Down()
        {
        }
    }
}
