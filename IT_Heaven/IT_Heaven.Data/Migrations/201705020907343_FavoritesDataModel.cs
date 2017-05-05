namespace IT_Heaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoritesDataModel : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.FavoritesDataModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CartDataModels");
            DropTable("dbo.FavoritesDataModels");
            DropTable("dbo.ArticleDataModels");
        }
    }
}
