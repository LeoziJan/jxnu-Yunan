namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Pnumber", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "IdCard", c => c.String(nullable: false));
            AddColumn("dbo.ScenicDetails", "ScenicDescribe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScenicDetails", "ScenicDescribe");
            DropColumn("dbo.Users", "IdCard");
            DropColumn("dbo.OrderDetails", "Pnumber");
        }
    }
}
