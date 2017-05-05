namespace IT_Heaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoritesDataModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FavoritesDataModels", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FavoritesDataModels", "UserId");
        }
    }
}
