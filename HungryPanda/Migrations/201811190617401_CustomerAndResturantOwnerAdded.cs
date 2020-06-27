namespace HungryPanda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndResturantOwnerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResturantOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResturantOwnerName = c.String(),
                        ResturantName = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        ResturantStatus = c.Int(nullable: false),
                        AreaId = c.Int(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId)
                .Index(t => t.AreaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResturantOwners", "AreaId", "dbo.Areas");
            DropIndex("dbo.ResturantOwners", new[] { "AreaId" });
            DropTable("dbo.ResturantOwners");
            DropTable("dbo.Customers");
        }
    }
}
