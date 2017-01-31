namespace VideoCollection.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoCollection.Data.VideoCollectionDataContext >
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(VideoCollection.Data.VideoCollectionDataContext  context)
        {
            RoleConfiguration.Seed(context);
            UserConfiguration.Seed(context);
            //VideoConfiguration.Seed(context);
        }
    }
}
