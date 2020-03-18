namespace FirstShop.Migrations
{
    using FirstShop.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<FirstShop.DAL.KursyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FirstShop.DAL.KursyContext";
        }

        protected override void Seed(FirstShop.DAL.KursyContext context)
        {
            KursyInitializer.SeedKursyData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
