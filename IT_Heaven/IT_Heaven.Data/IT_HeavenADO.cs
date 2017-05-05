using IT_Heaven.Models.Models.DataModels;

namespace IT_Heaven.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class IT_HeavenADO : DbContext
    {
        // Your context has been configured to use a 'IT_HeavenADO' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'IT_Heaven.Data.IT_HeavenADO' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'IT_HeavenADO' 
        // connection string in the application configuration file.
        public IT_HeavenADO()
            : base("name=IT_HeavenADO")
        {
         
        }

        public DbSet<ArticleDataModel> Articles { get; set; }
      
      
        public DbSet<ShopingNode> ShopingNodes{ get; set; }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}