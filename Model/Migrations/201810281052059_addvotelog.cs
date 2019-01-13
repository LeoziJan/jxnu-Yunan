namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvotelog : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.VoteLog");
        }
    }
}
