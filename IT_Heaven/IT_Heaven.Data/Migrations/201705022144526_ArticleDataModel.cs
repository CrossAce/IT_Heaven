namespace IT_Heaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleDataModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleDataModels", "Brand", c => c.String());
            AddColumn("dbo.ArticleDataModels", "Type", c => c.String());
            AddColumn("dbo.CartDataModels", "Brand", c => c.String());
            AddColumn("dbo.CartDataModels", "Discount", c => c.Int(nullable: false));
            AddColumn("dbo.CartDataModels", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartDataModels", "Type");
            DropColumn("dbo.CartDataModels", "Discount");
            DropColumn("dbo.CartDataModels", "Brand");
            DropColumn("dbo.ArticleDataModels", "Type");
            DropColumn("dbo.ArticleDataModels", "Brand");
        }
    }
}
