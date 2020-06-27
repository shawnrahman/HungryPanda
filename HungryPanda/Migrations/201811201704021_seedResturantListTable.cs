namespace HungryPanda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedResturantListTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ResturantOwners (ResturantOwnerName,ResturantName,JoinDate,Email,Address,Password,Phone,ResturantStatus,AreaId,Role) Values ('Muhammad','Atrium',5/8/2017,'atrium@gmail.com','h-12,r-34,Sector-9,Uttara Dhaka','123','88457898',1,1,'ResturantOwner')");
            Sql("INSERT INTO ResturantOwners (ResturantOwnerName,ResturantName,JoinDate,Email,Address,Password,Phone,ResturantStatus,AreaId,Role) Values ('Arif','Sauslis',5/5/2017,'sauslis@gmail.com','h-12,r-3,Sector-4,Uttara Dhaka','145','8856426',1,1,'ResturantOwner')");
            Sql("INSERT INTO ResturantOwners (ResturantOwnerName,ResturantName,JoinDate,Email,Address,Password,Phone,ResturantStatus,AreaId,Role) Values ('Saif','Food Ranger',5/8/2015,'foodranger@gmail.com','h-32,r-1,Gulshan Dhaka','125','84562547',1,1,'ResturantOwner')");

        }

        public override void Down()
        {

        }
    }
}
