using CameraBazaar.Models.EntityModels;

namespace CameraBazaar.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CameraBazaarContext : DbContext
    {
        // Your context has been configured to use a 'CameraBazaarContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CameraBazaar.Data.CameraBazaarContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CameraBazaarContext' 
        // connection string in the application configuration file.
        public CameraBazaarContext()
            : base("CameraBazaarContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}