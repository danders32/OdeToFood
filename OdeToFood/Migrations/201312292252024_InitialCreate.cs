namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FavoriteRestaurant = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RestaurantReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        BOdy = c.String(nullable: false, maxLength: 1024),
                        ReviewerName = c.String(),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RestaurantReviews", new[] { "RestaurantID" });
            DropForeignKey("dbo.RestaurantReviews", "RestaurantID", "dbo.Restaurants");
            DropTable("dbo.RestaurantReviews");
            DropTable("dbo.Restaurants");
            DropTable("dbo.UserProfile");
        }
    }
}
