namespace _17DH110151_LyQuyen.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_17DH110151_LyQuyen.Models.CSDL>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "_17DH110151_LyQuyen.Models.CSDL";
        }

        protected override void Seed(_17DH110151_LyQuyen.Models.CSDL context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
