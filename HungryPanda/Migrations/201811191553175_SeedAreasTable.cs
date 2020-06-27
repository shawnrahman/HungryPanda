namespace HungryPanda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAreasTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Areas ( Name,CityId) Values ( 'Gulshan-1',1)");
            Sql("INSERT INTO Areas ( Name,CityId) Values ( 'Baridhara',1)");
            Sql("INSERT INTO Areas ( Name,CityId) Values ( 'Uttara',1)");
            Sql("INSERT INTO Areas ( Name,CityId) Values ( 'Banani',1)");
            Sql("INSERT INTO Areas ( Name,CityId) Values ( 'Gulshan-2',1)");
            Sql("INSERT INTO Areas ( Name,CityId) Values ( 'Agarbad',2)");
            Sql("INSERT INTO Areas ( Name,CityId) Values ( 'Noapara',2)");
            Sql("INSERT INTO Areas ( Name,CityId) Values ( 'Nasirabad',2)");
            Sql("INSERT INTO Areas ( Name,CityId) Values ( 'Mistripara',2)");
        }
        
        public override void Down()
        {
        }
    }
}
