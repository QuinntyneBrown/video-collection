using System.Data.Entity.Migrations;
using VideoCollection.Data;
using VideoCollection.Data.Models;

namespace VideoCollection.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(VideoCollectionDataContext context) {

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = "[Video Collection Security Roles] System"
            });

            context.SaveChanges();
        }
    }
}
