namespace HungryPanda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CuisineAndResturantMenuAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ResturantOwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResturantOwners", t => t.ResturantOwnerId, cascadeDelete: true)
                .Index(t => t.ResturantOwnerId);
            
            CreateTable(
                "dbo.ResturantMenuCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResturantMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodItem = c.String(),
                        Price = c.Single(nullable: false),
                        Ratio = c.String(),
                        ResturantMenuCategoryId = c.Int(nullable: false),
                        ResturantOwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResturantMenuCategories", t => t.ResturantMenuCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ResturantOwners", t => t.ResturantOwnerId, cascadeDelete: true)
                .Index(t => t.ResturantMenuCategoryId)
                .Index(t => t.ResturantOwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResturantMenus", "ResturantOwnerId", "dbo.ResturantOwners");
            DropForeignKey("dbo.ResturantMenus", "ResturantMenuCategoryId", "dbo.ResturantMenuCategories");
            DropForeignKey("dbo.Cuisines", "ResturantOwnerId", "dbo.ResturantOwners");
            DropIndex("dbo.ResturantMenus", new[] { "ResturantOwnerId" });
            DropIndex("dbo.ResturantMenus", new[] { "ResturantMenuCategoryId" });
            DropIndex("dbo.Cuisines", new[] { "ResturantOwnerId" });
            DropTable("dbo.ResturantMenus");
            DropTable("dbo.ResturantMenuCategories");
            DropTable("dbo.Cuisines");
        }
    }
}
