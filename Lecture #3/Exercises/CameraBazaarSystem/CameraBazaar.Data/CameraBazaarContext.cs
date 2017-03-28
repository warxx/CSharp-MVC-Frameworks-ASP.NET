using CameraBazaar.Models.EntityModels;

namespace CameraBazaar.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CameraBazaarContext : DbContext
    {
        public CameraBazaarContext()
            : base("name=CameraBazaar")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Login> Logins { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}