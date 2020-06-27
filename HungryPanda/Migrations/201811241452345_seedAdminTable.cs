namespace HungryPanda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedAdminTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Admins ( Name,Gender,DOB,Email,Address,Password,Phone,Role) Values ( 'Rakib',1,'1996-12-05 08:08:11','rakib@gmail.com','h-12,r-15,Gulshan-2 Dhaka','1234',8854128,'admin')");

        }

        public override void Down()
        {
        }
    }
}
