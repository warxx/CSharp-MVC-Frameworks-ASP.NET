using CameraBazaar.Models.EntityModels;

namespace CameraBazaar.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CameraBazaarContext : DbContext
    {
        public CameraBazaarContext()
            : base("CameraBazaarContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}