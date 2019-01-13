namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intitial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsDetails",
                c => new
                    {
                        NewsDetId = c.Int(nullable: false, identity: true),
                        NewsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        NewsImg = c.String(),
                    })
                .PrimaryKey(t => t.NewsDetId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.News", t => t.NewsId)
                .Index(t => t.NewsId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsDetails", "NewsId", "dbo.News");
            DropForeignKey("dbo.NewsDetails", "UserId", "dbo.Users");
            DropIndex("dbo.NewsDetails", new[] { "UserId" });
            DropIndex("dbo.NewsDetails", new[] { "NewsId" });
            DropTable("dbo.NewsDetails");
        }
    }
}
