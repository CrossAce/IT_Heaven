namespace IT_Heaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleDataModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartDataModels", "UserName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartDataModels", "UserName");
        }
    }
}
