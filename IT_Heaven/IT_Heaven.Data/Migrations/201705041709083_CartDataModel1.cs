namespace IT_Heaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartDataModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CartDataModels", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CartDataModels", "UserName", c => c.Int(nullable: false));
        }
    }
}
