namespace HungryPanda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResturantReviewAndOrdersTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OverallScore = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderedMenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ResturantMenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.ResturantMenus", t => t.ResturantMenuId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ResturantMenuId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(),
                        OrderStatus = c.Int(nullable: false),
                        ResturantName = c.String(),
                        CustomerId = c.Int(nullable: false),
                        ReviewId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Reviews", t => t.ReviewId)
                .Index(t => t.CustomerId)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResturantReviewId = c.Int(nullable: false),
                        DeliveryReviewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryReviews", t => t.DeliveryReviewId, cascadeDelete: true)
                .ForeignKey("dbo.ResturantReviews", t => t.ResturantReviewId, cascadeDelete: true)
                .Index(t => t.ResturantReviewId)
                .Index(t => t.DeliveryReviewId);
            
            CreateTable(
                "dbo.ResturantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TasteScore = c.Int(nullable: false),
                        PriceScore = c.Int(nullable: false),
                        OverallScore = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedMenuItems", "ResturantMenuId", "dbo.ResturantMenus");
            DropForeignKey("dbo.OrderedMenuItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.Reviews", "ResturantReviewId", "dbo.ResturantReviews");
            DropForeignKey("dbo.Reviews", "DeliveryReviewId", "dbo.DeliveryReviews");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Reviews", new[] { "DeliveryReviewId" });
            DropIndex("dbo.Reviews", new[] { "ResturantReviewId" });
            DropIndex("dbo.Orders", new[] { "ReviewId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderedMenuItems", new[] { "ResturantMenuId" });
            DropIndex("dbo.OrderedMenuItems", new[] { "OrderId" });
            DropTable("dbo.ResturantReviews");
            DropTable("dbo.Reviews");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderedMenuItems");
            DropTable("dbo.DeliveryReviews");
        }
    }
}
