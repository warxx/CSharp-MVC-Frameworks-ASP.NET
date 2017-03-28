namespace CameraBazaar.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CameraBazaar.Data.CameraBazaarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CameraBazaar.Data.CameraBazaarContext context)
        {
        }
    }
}
