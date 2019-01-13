namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminScenic",
                c => new
                    {
                        ASId = c.Int(nullable: false, identity: true),
                        Actions = c.String(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        ActTime = c.DateTime(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ASId)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .ForeignKey("dbo.Scenic", t => t.ScenicId, cascadeDelete: true)
                .Index(t => t.ScenicId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminPassWard = c.String(nullable: false),
                        AdminName = c.String(nullable: false),
                        HeadImg = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Scenic",
                c => new
                    {
                        ScenicId = c.Int(nullable: false, identity: true),
                        ScenicTitle = c.String(nullable: false),
                        City = c.String(nullable: false),
                        type = c.String(nullable: false),
                        ScenicContent = c.String(nullable: false),
                        ScenicVote = c.Int(nullable: false),
                        ScenicStyle = c.String(nullable: false),
                        ScenicPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Days = c.Int(nullable: false),
                        ScenicCoverImg = c.String(nullable: false),
                        ScenicKeyWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ScenicId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ScenicId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        BeginTime = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Transport = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Scenic", t => t.ScenicId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ScenicId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserPassward = c.String(nullable: false),
                        UserTel = c.Long(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        UserAddress = c.String(nullable: false),
                        UserHeadimg = c.String(),
                        Usermotto = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PostTime = c.DateTime(nullable: false),
                        NewsTitle = c.String(nullable: false),
                        NewsContent = c.String(nullable: false),
                        NewsVote = c.Int(nullable: false),
                        NewsCoverImg = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Talks",
                c => new
                    {
                        TalkId = c.Int(nullable: false, identity: true),
                        NewsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        TPostTime = c.DateTime(nullable: false),
                        TalkContent = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TalkId)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.NewsId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ScenicDetails",
                c => new
                    {
                        ScenicDetailId = c.Int(nullable: false, identity: true),
                        ScenicId = c.Int(nullable: false),
                        ScenicName = c.String(nullable: false),
                        ScenicImg = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ScenicDetailId)
                .ForeignKey("dbo.Scenic", t => t.ScenicId, cascadeDelete: true)
                .Index(t => t.ScenicId);
            
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
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.AdminScenic", "ScenicId", "dbo.Scenic");
            DropForeignKey("dbo.AdminScenic", "AdminId", "dbo.Admins");
            DropIndex("dbo.ScenicDetails", new[] { "ScenicId" });
            DropIndex("dbo.Talks", new[] { "UserId" });
            DropIndex("dbo.Talks", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ScenicId" });
            DropIndex("dbo.OrderDetails", new[] { "UserId" });
            DropIndex("dbo.AdminScenic", new[] { "AdminId" });
            DropIndex("dbo.AdminScenic", new[] { "ScenicId" });
            DropTable("dbo.ScenicDetails");
            DropTable("dbo.Talks");
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
