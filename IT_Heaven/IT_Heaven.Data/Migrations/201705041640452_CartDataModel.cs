namespace IT_Heaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartDataModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartDataModels", "Discount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartDataModels", "Discount", c => c.Int(nullable: false));
        }
    }
}
