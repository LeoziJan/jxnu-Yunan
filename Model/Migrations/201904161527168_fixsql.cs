namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixsql : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.NewsCollect",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VoteLog",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        NewsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        VoteTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScenicDetails", "ScenicId", "dbo.Scenic");
            DropForeignKey("dbo.OrderDetails", "ScenicId", "dbo.Scenic");
            DropForeignKey("dbo.OrderDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.Talks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.News", "UserId", "dbo.Users");
            DropForeignKey("dbo.Talks", "NewsId", "dbo.News");
            DropForeignKey("dbo.NewsDetails", "NewsId", "dbo.News");
            DropForeignKey("dbo.NewsDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.AdminScenic", "ScenicId", "dbo.Scenic");
            DropForeignKey("dbo.AdminScenic", "AdminId", "dbo.Admins");
            DropIndex("dbo.ScenicDetails", new[] { "ScenicId" });
            DropIndex("dbo.Talks", new[] { "UserId" });
            DropIndex("dbo.Talks", new[] { "NewsId" });
            DropIndex("dbo.NewsDetails", new[] { "UserId" });
            DropIndex("dbo.NewsDetails", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ScenicId" });
            DropIndex("dbo.OrderDetails", new[] { "UserId" });
            DropIndex("dbo.AdminScenic", new[] { "AdminId" });
            DropIndex("dbo.AdminScenic", new[] { "ScenicId" });
            DropTable("dbo.VoteLog");
            DropTable("dbo.NewsCollect");
            DropTable("dbo.ScenicDetails");
            DropTable("dbo.Talks");
            DropTable("dbo.NewsDetails");
            DropTable("dbo.News");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Scenic");
            DropTable("dbo.Admins");
            DropTable("dbo.AdminScenic");
        }
    }
}
