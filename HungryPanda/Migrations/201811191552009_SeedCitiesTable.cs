namespace HungryPanda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCitiesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cities ( Name) Values ( 'Dhaka')");
            Sql("INSERT INTO Cities ( Name) Values ( 'Chittagong')");
            Sql("INSERT INTO Cities ( Name) Values ( 'Khulna')");
            Sql("INSERT INTO Cities ( Name) Values ( 'Sylhet')");
            Sql("INSERT INTO Cities ( Name) Values ( 'Comilla')");
        }
        
        public override void Down()
        {
        }
    }
}
