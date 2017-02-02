using System.Data.Entity.Migrations;
using VideoCollection.Data;
using VideoCollection.Data.Models;

namespace VideoCollection.Migrations
{
    public class VideoConfiguration
    {
        public static void Seed(VideoCollectionDataContext context) {

            //context.Videos.AddOrUpdate(x => x.Title, new Video()
            //{

            //});

            context.SaveChanges();
        }
    }
}
