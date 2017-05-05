namespace IT_Heaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoritesDataModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FavoritesDataModels", "UserName", c => c.String());
            DropColumn("dbo.FavoritesDataModels", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FavoritesDataModels", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.FavoritesDataModels", "UserName");
        }
    }
}
