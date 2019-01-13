namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "FinishTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "BuildTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "FinishTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "FinishTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "BuildTime");
            DropColumn("dbo.OrderDetails", "FinishTime");
        }
    }
}
