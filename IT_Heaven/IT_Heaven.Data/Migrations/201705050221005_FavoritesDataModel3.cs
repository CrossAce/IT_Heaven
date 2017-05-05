namespace IT_Heaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoritesDataModel3 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FavoritesDataModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FavoritesDataModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
