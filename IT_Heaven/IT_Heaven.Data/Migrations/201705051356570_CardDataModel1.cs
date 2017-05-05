namespace IT_Heaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardDataModel1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CartDataModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartDataModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Image = c.Binary(),
                        Name = c.String(),
                        Brand = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(),
                        Category = c.String(),
                        BoughtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
