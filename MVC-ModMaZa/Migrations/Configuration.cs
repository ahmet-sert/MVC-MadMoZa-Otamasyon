namespace MVC_ModMaZa.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_ModMaZa.Models.DbSınıflar.Contex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

        }

        protected override void Seed(MVC_ModMaZa.Models.DbSınıflar.Contex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
